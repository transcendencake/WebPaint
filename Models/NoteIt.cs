using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class NoteIt
    {
        public string Id { get; set; }
        public string Options { get; set; }
        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                NoteIt t = (NoteIt)obj;
                return (Id == t.Id);
            }
        }
    }
}