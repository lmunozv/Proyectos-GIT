using Bizagi.Business.Reports.Components.DAL;
using Bizagi.Business.Reports.Models;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Bizagi.Business.Reports.Components
{
    public static class Grapher
    {
        #region Propiedades
        private static DataManager dal;
        private static DataManager Dal
        {
            get
            {
                if (dal == null)
                {
                    dal = new DataManager();
                }
                return dal;
            }
        }
        #endregion

        public static Highcharts GetGraphic(MenuBO menu)
        {
            try
            {
                ChartTypes chartType = (ChartTypes)menu.GraphicsType;

                #region Parameters
                object[] parameter = GetParameters(menu);
                #endregion

                #region Type
                switch (chartType)
                {
                    case ChartTypes.Area:
                        return AreaChart(menu, parameter);
                    case ChartTypes.Bar:
                        return BarChart(menu, parameter);
                    case ChartTypes.Pie:
                        return PieChart(menu, parameter);
                    case ChartTypes.Gauge:
                        return GaugeChart(menu, parameter);
                    default:
                        return StackedBarChart(menu, parameter);
                }
                #endregion
            }
            catch (Exception ex)
            {

                //Util.WriteEvent(ex.Message+ "  "+ ex.StackTrace);
                throw ex;
            }
           
        }

        public static DataTable GetDatatailsDs(MenuBO menu)
        {
            DataManager dal = new Components.DAL.DataManager();
            object[] parameter = new object[1] { menu.GraphicsType };
            var ds = dal.GetDetails(menu.ProcedureName, parameter);
            DataTable dt = new DataTable();
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }       

        public static List<InformationDetail> GetDateils(MenuBO menu)
        {
            DataManager dal = new Components.DAL.DataManager();
            object[] parameter = new object[1] { menu.GraphicsType };
            var ds = dal.GetDetails(menu.ProcedureName, parameter);
            InformationDetail details = new InformationDetail();
            List<InformationDetail> listDetails = new List<Models.InformationDetail>();
            if (ds.Tables.Count > 0)
            {
                DataTable datos = ds.Tables[0];
                foreach (DataRow item in datos.Rows)
                {
                    details.Id = item[0].ToString();
                    details.Field = item[1].ToString();
                    var results = from myRow in ds.Tables[1].AsEnumerable()
                                  where myRow.Field<string>("Id") == details.Id
                                  select myRow;
                    foreach (DataRow itemDatos in results)
                    {
                        details.Value = itemDatos[1].ToString();
                    }
                    listDetails.Add(details);
                }
            }
            return listDetails;
        }

        #region Privados

        private static Highcharts PieChart(MenuBO menu, object[] parameter)
        {
            
            List<Series> series = Dal.GetData(menu.ProcedureName, parameter);
            object[] oComplement = new object[series.Count];
            int y = 0;
            #region Data
            foreach (var item in series)
            {
                object[] oData = oData = new object[2];
                oData[0] = item.Name;
                oData[1] = item.Data.ArrayData[0];
                oComplement[y] = oData;
                y += 1;
            }
            #endregion

            #region Chart
            Highcharts chart = new Highcharts("chart"+menu.Oid)
               .InitChart(new Chart { PlotShadow = false })
               .SetTitle(new Title { Text = menu.Title })
               .SetTooltip(new Tooltip { Formatter = "function() { return '<b>'+ this.point.name +'</b>: '+ this.percentage +' %'; }" })
               .SetPlotOptions(new PlotOptions
               {
                   Pie = new PlotOptionsPie
                   {
                       AllowPointSelect = true,
                       Cursor = Cursors.Pointer,
                       DataLabels = new PlotOptionsPieDataLabels
                       {
                           Color = ColorTranslator.FromHtml("#000000"),
                           ConnectorColor = ColorTranslator.FromHtml("#000000"),
                           Formatter = "function() { return '<b>'+ this.point.name +'</b>: '+ this.percentage +' %'; }"
                       }
                   }
               })
               .SetSeries(new Series
               {
                   Type = ChartTypes.Pie,
                   Name = "Browser share",
                   Data = new Data(oComplement)
               });
            #endregion

            return chart;
        }

        private static Highcharts BarChart(MenuBO menu, object[] parameter)
        {
           
            List<Series> series = Dal.GetData(menu.ProcedureName, parameter);
            List<string> axis = Dal.GetAxis(menu.DataAxis, null);
            #region Chart
            Highcharts chart = new Highcharts("chart" + menu.Oid)
               .InitChart(new Chart { DefaultSeriesType = ChartTypes.Column })
               .SetTitle(new Title { Text = menu.Title })
               .SetXAxis(new XAxis { Categories = axis.ToArray() })
               .SetYAxis(new YAxis
               {
                   Min = 0,
                   Title = new YAxisTitle { Text = menu.Title }
               })
               .SetLegend(new Legend
               {
                   Layout = Layouts.Vertical,
                   Align = HorizontalAligns.Left,
                   VerticalAlign = VerticalAligns.Top,
                   X = 100,
                   Y = 70,
                   Floating = true,
                   BackgroundColor = new BackColorOrGradient(ColorTranslator.FromHtml("#FFFFFF")),
                   Shadow = true
               })
               .SetTooltip(new Tooltip { Formatter = @"function() { return ''+ this.x +': '+ this.y +' mm'; }" })
               .SetPlotOptions(new PlotOptions
               {
                   Column = new PlotOptionsColumn
                   {
                       PointPadding = 0.2,
                       BorderWidth = 0
                   }
               })
               .SetSeries(series.ToArray());
            #endregion

            return chart;
        }

        private static Highcharts AreaChart(MenuBO menu, object[] parameter)
        {
        
            List<Series> series = Dal.GetData(menu.ProcedureName, parameter);
            #region Chart
            Highcharts chart = new Highcharts("chart" + menu.Oid)
                .InitChart(new Chart { DefaultSeriesType = ChartTypes.Area })
                .SetTitle(new Title { Text = menu.Title })
                .SetXAxis(new XAxis { Categories = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" } })
               .SetYAxis(new YAxis
               {
                   Min = 0,
                   Title = new YAxisTitle { Text = menu.Title }
               })
                .SetPlotOptions(new PlotOptions
                {
                    Area = new PlotOptionsArea
                    {
                        PointStart = new PointStart(0),
                        Marker = new PlotOptionsAreaMarker
                        {
                            Enabled = false,
                            Symbol = "circle",
                            Radius = 2,
                            States = new PlotOptionsAreaMarkerStates
                            {
                                Hover = new PlotOptionsAreaMarkerStatesHover { Enabled = true }
                            }
                        }

                    }
                })
                .SetSeries(series.ToArray());
            #endregion

            return chart;
        }

        private static Highcharts GaugeChart(MenuBO menu, object[] parameter)
        {
            
            GaugeBO gauge = Dal.GetGauge(menu.ProcedureName, parameter);

            #region Chart
            Highcharts chart = new Highcharts("chart" + menu.Oid)
                .InitChart(new Chart
                {
                    Type = ChartTypes.Gauge,
                    PlotBackgroundColor = null,
                    PlotBackgroundImage = null,
                    PlotBorderWidth = 0,
                    PlotShadow = false
                })
                .SetTitle(new Title { Text = menu.Title })
                .SetPane(new Pane
                {
                    StartAngle = -150,
                    EndAngle = 150,
                    Background = new[]
                    {
                        new BackgroundObject
                        {
                            BackgroundColor = new BackColorOrGradient(new Gradient
                            {
                                LinearGradient = new[] { 0, 0, 0, 1 },
                                Stops = new object[,] { { 0, "#FFF" }, { 1, "#333" } }
                            }),
                            BorderWidth = new PercentageOrPixel(0),
                            OuterRadius = new PercentageOrPixel(109, true)
                        },
                        new BackgroundObject
                        {
                            BackgroundColor = new BackColorOrGradient(new Gradient
                            {
                                LinearGradient = new[] { 0, 0, 0, 1 },
                                Stops = new object[,] { { 0, "#333" }, { 1, "#FFF" } }
                            }),
                            BorderWidth = new PercentageOrPixel(1),
                            OuterRadius = new PercentageOrPixel(107, true)
                        },
                        new BackgroundObject(),
                        new BackgroundObject
                        {
                            BackgroundColor = new BackColorOrGradient(ColorTranslator.FromHtml("#DDD")),
                            BorderWidth = new PercentageOrPixel(0),
                            OuterRadius = new PercentageOrPixel(105, true),
                            InnerRadius = new PercentageOrPixel(103, true)
                        }
                    }
                })
                .SetYAxis(new YAxis
                {
                    Min = 0,
                    Max = gauge.ObjectiveValue,

                    //MinorTickInterval = "auto",
                    MinorTickWidth = 1,
                    MinorTickLength = 10,
                    MinorTickPosition = TickPositions.Inside,
                    MinorTickColor = ColorTranslator.FromHtml("#666"),
                    TickPixelInterval = 30,
                    TickWidth = 2,
                    TickPosition = TickPositions.Inside,
                    TickLength = 10,
                    TickColor = ColorTranslator.FromHtml("#666"),
                    Labels = new YAxisLabels
                    {
                        Step = 2,
                        //Rotation = "auto"
                    },
                    Title = new YAxisTitle { Text = "Creditos" },
                    PlotBands = new[]
                    {
                        new YAxisPlotBands { From = 0, To = gauge.Range, Color = ColorTranslator.FromHtml("#DF5353") },
                        new YAxisPlotBands { From = gauge.Range, To = gauge.Range *2, Color = ColorTranslator.FromHtml("#DDDF0D") },
                        new YAxisPlotBands { From = gauge.Range *2, To = gauge.Range *3, Color = ColorTranslator.FromHtml("#55BF3B") }
                    }
                })
                .SetSeries(new Series
                {
                    Name = gauge.Descripcion,
                    Data = new Data(new object[] { gauge.RealValue })
                });
            #endregion

            return chart;
        }

        private static Highcharts StackedBarChart(MenuBO menu, object[] parameter)
        {           
            List<Series> series = Dal.GetData(menu.ProcedureName, parameter);
            List<string> axis = Dal.GetAxis(menu.DataAxis, null);

            #region Chart
            Highcharts chart = new Highcharts("chart" + menu.Oid)
              .InitChart(new Chart { DefaultSeriesType = ChartTypes.Bar })
              .SetTitle(new Title { Text = menu.Title })
              .SetXAxis(new XAxis { Categories = axis.ToArray() })
              .SetYAxis(new YAxis
              {
                  Min = 0,
                  Title = new YAxisTitle { Text = menu.Title }
              })
              .SetTooltip(new Tooltip { Formatter = "function() { return ''+ this.series.name +': '+ this.y +''; }" })
              .SetPlotOptions(new PlotOptions { Bar = new PlotOptionsBar { Stacking = Stackings.Normal } })
              .SetSeries(series.ToArray());
            #endregion

            return chart;
        }

        private static object[] GetParameters(MenuBO menu)
        {
            object[] filter = new object[1] { menu.Oid };
            List<ParametersBO> lstParameters = Dal.GetParameters(filter);

            object[] parameters = new object[lstParameters.Count + 1];
            int control = 1;
            parameters[0] = menu.GraphicsType;

            foreach (var item in lstParameters)
            {
                parameters[control] = SetDataType(item);
                control++;
            }
            return parameters;
        }

        private static object SetDataType(ParametersBO parameter)
        {
            object response = new object();           
            switch ((EnumDataType)parameter.DataType)
            {
                case EnumDataType.iInteger:
                    response = parameter.IValue;
                    break;
                case EnumDataType.sString:
                    response = parameter.SValue;
                    break;
                case EnumDataType.dDateTime:
                    response = parameter.DValue;
                    break;
                case EnumDataType.dDouble:
                    response = parameter.DoValue;
                    break;
                case EnumDataType.dDecimal:
                    response = parameter.CValue;
                    break;
                case EnumDataType.bBooean:
                    response = parameter.BValue;
                    break;
                default:
                    throw new Exception("Tipo de Dato No Implementado");
            }
            return response;
        }
        #endregion
    }
}