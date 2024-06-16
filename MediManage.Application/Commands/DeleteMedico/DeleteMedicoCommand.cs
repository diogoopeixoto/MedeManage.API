﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediManage.Application.Commands.DeleteMedico
{
    public class DeleteMedicoCommand : IRequest<Unit>
    {
        public DeleteMedicoCommand(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
    }
}
