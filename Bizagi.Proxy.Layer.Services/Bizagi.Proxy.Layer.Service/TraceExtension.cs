﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;

public class TraceExtension : SoapExtension
{
    Stream oldStream;
    Stream newStream;
    string filename;


    public override Stream ChainStream(Stream stream)
    {
        System.Diagnostics.Debug.WriteLine("ChainStream");
        oldStream = stream;
        newStream = new MemoryStream();
        return newStream;
    }


    public override object GetInitializer(LogicalMethodInfo methodInfo, SoapExtensionAttribute attribute)
    {
        return ((TraceExtensionAttribute)attribute).Filename;
    }


    public override object GetInitializer(Type WebServiceType)
    {
        return "C:\\" + WebServiceType.FullName + ".log";
    }


    public override void Initialize(object initializer)
    {
        DateTime dateFile = DateTime.Today;
        String day = Convert.ToString(dateFile.Day);
        String month = Convert.ToString(dateFile.Month);
        String year = Convert.ToString(dateFile.Year);
        filename = (string)initializer + "" + year + "-" + month + "-" + day + ".log";
    }


    public override void ProcessMessage(SoapMessage message)
    {
        switch (message.Stage)
        {
            case SoapMessageStage.BeforeSerialize:
                break;
            case SoapMessageStage.AfterSerialize:
                WriteOutput(message);
                break;
            case SoapMessageStage.BeforeDeserialize:
                WriteInput(message);
                break;
            case SoapMessageStage.AfterDeserialize:
                break;
            default:
                throw new Exception("invalid stage");
        }
    }


    public void WriteOutput(SoapMessage message)
    {
        newStream.Position = 0;
        FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write);
        StreamWriter w = new StreamWriter(fs);

        string soapString = (message is SoapServerMessage) ? "SoapResponse" : "SoapRequest";
        w.WriteLine("-----" + soapString + " at " + DateTime.Now);
        w.Flush();
        Copy(newStream, fs);
        w.Close();
        newStream.Position = 0;
        Copy(newStream, oldStream);
    }


    public void WriteInput(SoapMessage message)
    {
        Copy(oldStream, newStream);
        FileStream fs = new FileStream(filename, FileMode.Append, FileAccess.Write);
        StreamWriter w = new StreamWriter(fs);

        string soapString = (message is SoapServerMessage) ?
            "SoapRequest" : "SoapResponse";
        w.WriteLine("-----" + soapString +
            " at " + DateTime.Now);
        w.Flush();
        newStream.Position = 0;
        Copy(newStream, fs);
        w.Close();
        newStream.Position = 0;
    }


    void Copy(Stream from, Stream to)
    {
        TextReader reader = new StreamReader(from);
        TextWriter writer = new StreamWriter(to);
        writer.WriteLine(reader.ReadToEnd());
        writer.Flush();
    }
}


[AttributeUsage(AttributeTargets.Method)]
public class TraceExtensionAttribute : SoapExtensionAttribute
{
    private string filename = "c:\\log.txt";
    private int priority;


    public override Type ExtensionType
    {
        get { return typeof(TraceExtension); }
    }


    public override int Priority
    {
        get { return priority; }
        set { priority = value; }
    }


    public string Filename
    {
        get
        {
            return filename;
        }
        set
        {
            filename = value;
        }
    }
}

