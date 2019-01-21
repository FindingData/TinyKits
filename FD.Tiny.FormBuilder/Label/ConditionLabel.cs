///////////////////////////////////////////////////////////
//  ConditionLabel.cs
//  Implementation of the Class ConditionLabel
//  Generated by Enterprise Architect
//  Created on:      28-12��-2018 9:02:27
//  Original author: drago
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using FD.Tiny.FormBuilder;
namespace FD.Tiny.FormBuilder {
	public class ConditionLabel : Label {

		public ConditionLabel(){

			this.label_type = LabelType.condition;
		}
 
        /// 
        /// <param name="source"></param>
        public override string GetValue(Func<string, string> source){

			foreach (var condition in label_config.condition_list)
			{
			    this.inner_value = condition.condition_expr;
	
			    if (BoolExpression(source))
			    {
			        if (condition.condition_item.value_method == ValueMethod.Const)
			        {
			            return condition.condition_item.inner_value;
			        }
			        else
			        {
			            this.inner_value = condition.condition_item.inner_value;
	
			            return CalcExpression(source);
			        }
			    }
			}
			return string.Empty;
		}

	}//end ConditionLabel

}//end namespace FD.Tiny.FormBuilder