﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProctoringManagement.Repository.Exceptions;

public class BadRequestException : EntityException
{
    public BadRequestException(string message) : base(message)
    {
    }
}

