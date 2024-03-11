﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.FeatureCommands
{
    public class UpdateFeatureCommand:IRequest
    {
        public int FeatureId { get; set; }
        public string Name { get; set; }
    }
}
