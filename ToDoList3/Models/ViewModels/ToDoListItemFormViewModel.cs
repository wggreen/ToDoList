using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList3.Models.ViewModels
{
    public class ToDoListItemFormViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int ToDoStatusId { get; set; }

        [Required]
        public ToDoStatus ToDoStatus { get; set; }

        [NotMapped]
        public List<SelectListItem> ToDoStatusOptions { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
