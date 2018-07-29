using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoSeller.Models;
using System.ComponentModel.DataAnnotations;

namespace AutoSeller.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

  //      [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

         //membershipType is domain object and if we want to use it here we should create its own dto
        //the current dto consists only of simple variable types like int etc.which are part of its object (Customer)
      //  public MembershipType MembershipType { get; set; }

        //no need to ser Required, because the byte variables are implicitly required
        public byte MembershipTypeId { get; set; }
    }
}