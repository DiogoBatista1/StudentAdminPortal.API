﻿using StudentAdminPortal.API.DataModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentAdminPortal.API.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudents();
        Task<Student> GetStudentAsync(Guid studentId);
    }
}
