using Drive.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using File = Drive.Data.Entities.Models.File;

namespace Drive.Data.Seeds
{
    public static class DatabaseSeeder
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasData(new List<User>
                {
                    new User("alice@gmail.com",HashPassword("Alice123"))
                    {
                        Id=1
                    },
                    new User("bob@gmail.com",HashPassword("Bob007"))
                    {
                        Id=2
                    },
                    new User("charlie@gmail.com",HashPassword("C12345"))
                    {
                        Id=3
                    },
                    new User("frane@gmail.com",HashPassword("fb123"))
                    {
                        Id=4
                    }
                });

            builder.Entity<Folder>()
                .HasData(new List<Folder>
                {
                    new Folder 
                    { 
                        Id = 1,
                        Name = "Work",
                        CreatedAt = DateTime.UtcNow,
                        LastModified = DateTime.UtcNow,
                        ParentFolderId = null,
                        OwnerId = 1 
                    },
                    new Folder
                    {
                        Id = 2,
                        Name = "Personal",
                        CreatedAt = DateTime.UtcNow,
                        LastModified = DateTime.UtcNow,
                        ParentFolderId = null,
                        OwnerId = 2
                    },
                    new Folder
                    {
                        Id = 3,
                        Name = "Shared Folder",
                        CreatedAt = DateTime.UtcNow,
                        LastModified = DateTime.UtcNow,
                        ParentFolderId = null,
                        OwnerId = 1
                    },
                    new Folder
                    {
                        Id = 4,
                        Name = "Images",
                        CreatedAt = DateTime.UtcNow,
                        LastModified = DateTime.UtcNow,
                        ParentFolderId = null,
                        OwnerId = 3
                    },
                    new Folder
                    {
                        Id = 5,
                        Name = "Projects",
                        CreatedAt = DateTime.UtcNow,
                        LastModified = DateTime.UtcNow,
                        ParentFolderId = 1,
                        OwnerId = 1
                    }
                });

            builder.Entity<File>()
                .HasData(new List<File>
                {
                    new File
                    {
                        Id = 1,
                        Name = "report.docx",
                        Content = "Work report content",
                        CreatedAt = DateTime.UtcNow,
                        LastModifiedAt = DateTime.UtcNow,
                        FolderId = 1,
                        OwnerId= 1
                    },
                    new File
                    {
                        Id = 2,
                        Name = "photo.jpg",
                        Content = null,
                        CreatedAt = DateTime.UtcNow,
                        LastModifiedAt = DateTime.UtcNow,
                        FolderId = 2,
                        OwnerId= 2
                    },
                    new File
                    {
                        Id = 3,
                        Name = "shared_notes.txt",
                        Content = "Collaborative notes",
                        CreatedAt = DateTime.UtcNow,
                        LastModifiedAt = DateTime.UtcNow,
                        FolderId = 3,
                        OwnerId= 1
                    },
                    new File
                    {
                        Id = 4,
                        Name = "image1.png",
                        Content = null,
                        CreatedAt = DateTime.UtcNow,
                        LastModifiedAt = DateTime.UtcNow,
                        FolderId = 4,
                        OwnerId= 3
                    },
                    new File
                    {
                        Id = 5,
                        Name = "tasks.txt",
                        Content = "Project tasks content",
                        CreatedAt = DateTime.UtcNow,
                        LastModifiedAt = DateTime.UtcNow,
                        FolderId = 5,
                        OwnerId= 1
                    },
                    new File
                    {
                        Id = 6,
                        Name = "root_file_1.txt",
                        Content = "File in root directory",
                        CreatedAt = DateTime.UtcNow,
                        LastModifiedAt = DateTime.UtcNow,
                        FolderId = null,
                        OwnerId= 1
                    },
                    new File
                    {
                        Id = 7,
                        Name = "root_file_2.txt",
                        Content = "File in root directory",
                        CreatedAt = DateTime.UtcNow,
                        LastModifiedAt = DateTime.UtcNow,
                        FolderId = null,
                        OwnerId= 2
                    }
                });

            builder.Entity<Comment>()
                .HasData(new List<Comment>
                {
                    new Comment
                    {
                        Id = 1,
                        Content = "Looks good!",
                        CreatedAt = DateTime.UtcNow,
                        LastModified = DateTime.UtcNow,
                        FileId = 1,
                        AuthorId= 2
                    },
                    new Comment
                    {
                        Id = 2,
                        Content = "Needs some changes.",
                        CreatedAt = DateTime.UtcNow,
                        LastModified = DateTime.UtcNow,
                        FileId = 1,
                        AuthorId= 3
                    },
                    new Comment
                    {
                        Id = 3,
                        Content = "Great work!",
                        CreatedAt = DateTime.UtcNow,
                        LastModified = DateTime.UtcNow,
                        FileId = 5,
                        AuthorId= 4
                    }
                });

            builder.Entity<SharedItem>()
                .HasData(new List<SharedItem>
                {
                    new SharedItem
                    {
                        Id = 1,
                        OwnerId = 1,
                        RecipientId = 2,
                        FolderId = null,
                        FileId = 3
                    },
                    new SharedItem
                    {
                        Id = 2,
                        OwnerId = 1,
                        RecipientId = 3,
                        FolderId = 3,
                        FileId = null
                    },
                    new SharedItem
                    {
                        Id = 3,
                        OwnerId = 3,
                        RecipientId = 4,
                        FolderId = 4,
                        FileId = null
                    },
                    new SharedItem
                    {
                        Id = 4,
                        OwnerId = 2,
                        RecipientId = 1,
                        FolderId = 2,
                        FileId = null
                    },
                    new SharedItem
                    {
                        Id = 5,
                        OwnerId = 1,
                        RecipientId = 3,
                        FolderId = null,
                        FileId = 6
                    }
                });
        }

        private static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
