﻿using DataLayer.Repositories;

namespace DataLayer
{
    public class UnitOfWork
    {
        public StudentsRepository Students { get; }
        public ClassRepository Classes { get; }

        public UsersRepository Users { get; }

        private readonly AppDbContext _dbContext;

        public GradesRepository Grades { get; }

        public RoleRepository Roles { get; }

        public UnitOfWork
        (
            AppDbContext dbContext,
            StudentsRepository studentsRepository,
            ClassRepository classes,
            GradesRepository gradesRepository,
            UsersRepository usersRepository,
            RoleRepository roleRepository
        )
        {
            _dbContext = dbContext;
            Students = studentsRepository;
            Classes = classes;
            Grades = gradesRepository;
            Users = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
            Roles = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
        }

        public void SaveChanges()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception exception)
            {
                var errorMessage = "Eroare la salvare : "
                    + $"{exception.Message}\n\n"
                    + $"{exception.InnerException}\n\n"
                    + $"{exception.StackTrace}\n\n";

                Console.WriteLine(errorMessage);
            }
        }
    }
}
