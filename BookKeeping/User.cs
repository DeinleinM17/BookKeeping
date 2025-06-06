// Matt Deinlein[mattdeinlein@gmail.com]
// @version: 1.0 06.06.2025
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeping
{
    public class User
    {
        // Properties for the User class with proper accessors
        public int Id { get; set; }
        public string Name { get; set; }  // Non-nullable
        public string Phone { get; set; }  // Non-nullable
        public string Email { get; set; }  // Non-nullable

        // Constructor to initialize a new User
        public User(string name, string phone, string email)
        {
            
            Name = name ?? throw new ArgumentNullException(nameof(name)); // Throw if null
            Phone = phone ?? throw new ArgumentNullException(nameof(phone)); // Throw if null
            Email = email ?? throw new ArgumentNullException(nameof(email)); // Throw if null
        }

        // Parameterless constructor (optional)
        public User()
        {
            
            Name = string.Empty;  // Default to empty string
            Phone = string.Empty;  // Default to empty string
            Email = string.Empty;  // Default to empty string
        }
    }
}

