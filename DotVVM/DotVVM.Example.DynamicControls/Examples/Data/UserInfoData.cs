using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotVVM.Example.DynamicControls.Examples.Data
{
    public class UserInfoData
    {
        public int ID { get; set; }

        //[Required(ErrorMessage = "The First Name field is required.")]
        //[StringLength(100)]
        public string Name { get; set; }

        //[Required(ErrorMessage = "The E-mail Address field is required.")]
        //[EmailAddress(ErrorMessage = "The E-mail Address format is not valid.")]
        //[StringLength(100)]
        public string Email { get; set; }
    }
}
