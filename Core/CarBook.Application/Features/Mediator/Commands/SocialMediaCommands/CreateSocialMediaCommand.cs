﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.SocialMediaCommands
{
    public class CreateSocialMediaCommand:IRequest
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }
    }
}
