using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using System.Collections;

namespace BAnimator.TypeConverters
{
    public class PointFTypeConverter : ExpandableObjectConverter
    {
        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
        {
            if (propertyValues == null)
            {
                throw new ArgumentNullException("propertyValues");
            }
            var X = propertyValues["X"];
            var Y = propertyValues["Y"];

            if (X == null || !(X is float) || Y == null || !(Y is float))
            {
                throw new ArgumentException("Invalid propertyValue");
            }
            return new PointF
            {
                X = (float)X, Y = (float)Y            
            };
        }
    }
}
