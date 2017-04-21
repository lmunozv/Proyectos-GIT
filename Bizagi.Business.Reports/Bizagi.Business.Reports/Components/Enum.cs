using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bizagi.Business.Reports.Components
{
    public enum EnumDataType
    {
        iInteger = 1,
        sString = 2,
        dDateTime =3,
        dDouble = 4,
        dDecimal =5,
        bBooean = 6
    }

    public enum ChartType
    {
        Area = 1,
        BarrasVerticales = 2,
        Pie = 3,
        Gauge = 4,
        BarrasHorizontales = 5,
        Detalles = 6,
        Pie3D = 7,
        Donut = 8
    }
}