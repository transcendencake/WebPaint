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

        public void AddLine(string line)
        {
            lines.Add(line);
            Clients.AllExcept(Context.ConnectionId).addLine(line);
        }
        public void RemoveLine(string line)
        {
            lines.Remove(line);
            Clients.AllExcept(Context.ConnectionId).removeLine(line);
        }
        public void AddTextField(int x, int y, int w, int h, string text)
        {
            bool existing = false;
            var newTextField = new TextField{ X = x, Y = y, W = w, H = h, TextContent = text };
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
            Clients.AllExcept(Context.ConnectionId).addTextField(x, y, w, h, text, existing);
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
            Clients.AllExcept(Context.ConnectionId).removeTextField(x, y);
        }
    }
}