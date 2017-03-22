using Business.DataAccessLayer.Consultants.ADO;
using Business.DataAccessLayer.Objects;
using Business.DataAccessLayer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.DataAccessLayer.Consultants.Factory
{
    public class ConsultantFactory
    {
        public static IGeneral<Persistent, BusinessObject> Create<Persistent, BusinessObject>(EnumConsultantType consultantType)
        {

            switch (consultantType)
            {
                case EnumConsultantType.Ado:
                    return new ConsultantReader<Persistent, BusinessObject>() as IConsultantReader<Persistent, BusinessObject>;
                case EnumConsultantType.Hibernate:
                    throw new Exception(DALMessage.Error_Factory);
                case EnumConsultantType.XPO:
                    throw new Exception(DALMessage.Error_Factory);
                default:
                    throw new Exception(DALMessage.Error_Factory);                    
            }
           
        }
    }
}
