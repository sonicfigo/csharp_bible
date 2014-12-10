using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bible1.Equals
{
    [Serializable]
    public class EqualityMembersEnvironment
    {
        protected bool Equals(EqualityMembersEnvironment other)
        {
            return string.Equals(Name, other.Name) && 
                string.Equals(PhysicalPath, other.PhysicalPath) && 
                string.Equals(BackupPath, other.BackupPath);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (PhysicalPath != null ? PhysicalPath.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (BackupPath != null ? BackupPath.GetHashCode() : 0);
                return hashCode;
            }
        }

        public string Name { get; set; }
        public string PhysicalPath { get; set; }
        public string BackupPath { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}
