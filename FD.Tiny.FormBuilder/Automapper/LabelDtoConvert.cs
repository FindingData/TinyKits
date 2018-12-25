using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.FormBuilder
{
    public class LabelDtoConvert : ITypeConverter<LabelPO, Label>
    {
        public Label Convert(LabelPO source, Label destination, ResolutionContext context)
        {
            var type = (LabelType)source.LABEL_TYPE;
            switch (type)
            {
                case LabelType.control:
                    destination = Mapper.Map<LabelPO, ControlLabel>(source);
                    break;
                case LabelType.variable:
                    destination = Mapper.Map<LabelPO, VariableLabel>(source);
                    break;
                case LabelType.condition:
                    destination = Mapper.Map<LabelPO, ConditionLabel>(source);
                    break;
                default:
                    break;
            }
            return destination;
        }
    }
}
