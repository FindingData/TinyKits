using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FD.Tiny.FormBuilder
{
    public class FormVariableDtoConvert : ITypeConverter<FormVariablePO, FormVariable>
    {
        public FormVariable Convert(FormVariablePO source, FormVariable destination, ResolutionContext context)
        {            
            var type = (VariableType)source.VARIABLE_TYPE;
            switch (type)
            {
                case VariableType.Variable:
                    destination = Mapper.Map<FormVariablePO, FormVariable>(source);
                    break;
                case VariableType.Label:
                    destination = Mapper.Map<FormVariablePO, LabelVariable>(source);
                    break;
                case VariableType.Condition:
                    destination =  Mapper.Map<FormVariablePO, ConditionVariable>(source);
                    break;
                default:
                    break;
            }
            return destination;
        }

        
    }
}
