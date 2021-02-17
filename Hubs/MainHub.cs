using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Hubs
{
    public class MainHub : Hub
    {
        static List<TextField> textFields = new List<TextField>();
        static List<string> lines = new List<string>();
        static List<NoteIt> notes = new List<NoteIt>();

        public void AddNote(string id, string options)
        {
            bool existing = false;
            var newNote = new NoteIt { Id = id, Options = options };
            foreach (var note in notes)
            {
                if (note.Equals(newNote))
                {
                    note.Options = newNote.Options;
                    existing = true;
                    break;
                }
            }
            if (!existing)
            {
                notes.Add(newNote);
                Clients.Others.addNote(id, options);
            }
            
        }
        public void AddLine(string line)
        {
            lines.Add(line);
            Clients.Others.addLine(line);
        }
        public void RemoveLine(string line)
        {
            lines.Remove(line);
            Clients.Others.removeLine(line);
        }
        public void AddTextField(int x, int y, int w, int h, string text)
        {
            bool existing = false;
            var newTextField = new TextField { X = x, Y = y, W = w, H = h, TextContent = text };
            foreach (var textField in textFields)
            {
                if (textField.Equals(newTextField))
                {
                    textField.TextContent = newTextField.TextContent;
                    existing = true;
                    break;
                }
            }
            if (!existing) textFields.Add(newTextField);
            Clients.Others.addTextField(x, y, w, h, text, existing);
        }
        public void RemoveTextField(int x, int y)
        {
            foreach (var textField in textFields)
            {
                if (textField.X == x && textField.Y == y)
                {
                    textFields.Remove(textField);
                    break;
                }
            }
            Clients.Others.removeTextField(x, y);
        }
    }
}