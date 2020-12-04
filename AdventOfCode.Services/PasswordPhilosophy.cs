using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Services.Model;

namespace AdventOfCode.Services
{
    /// <summary>
    /// Code related to the day 2 problem. Calculate the validity of a password database.
    /// </summary>
    public static class PasswordPhilosophy
    {
        public enum RentalPlace
        {
            Sleds,
            Tobogan
        }

        public static PasswordPolicy[] GetValidPasswords(IEnumerable<PasswordPolicy> input, RentalPlace rentalPlace)
        {
            return rentalPlace switch
            {
                RentalPlace.Sleds => GetValidPasswordsOldRentalPlace(input),
                RentalPlace.Tobogan => GetValidPasswordsRentalPlace(input),
                _ => throw new NotImplementedException()
            };
        }

        private static PasswordPolicy[] GetValidPasswordsOldRentalPlace(IEnumerable<PasswordPolicy> policies)
        {
            return policies.Where(p => p.IsValidForOldRentalPlace()).ToArray();
        }

        private static PasswordPolicy[] GetValidPasswordsRentalPlace(IEnumerable<PasswordPolicy> policies)
        {
            return policies.Where(p => p.IsValidForNewRentalPlace()).ToArray();

        }
    }
}