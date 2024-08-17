using ChatApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.DTOs.Message;

public class MessageRequest
{
    public string Content { get; set; }
    public MessageType MessageType { get; set; }
    public string SenderId { get; set; }
    public string ReceiverId { get; set; }
}
