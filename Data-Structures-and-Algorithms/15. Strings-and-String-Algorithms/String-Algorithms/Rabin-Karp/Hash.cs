using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabin_Karp
{
    public class Hash
    {
        private int hashBase;
        private int mod;
        private long patternHash;
        private long powerBase;
        private string pattern;

        public Hash(int hashBase, int mod, string pattern, int end)
        {
            this.powerBase = 1;
            this.pattern = pattern;
            this.hashBase = hashBase;
            this.mod = mod;
            this.patternHash = GenerateHash(pattern, end);
        }

        public long StringHash => this.patternHash;

        public void RollHash(char leftChar, char rightChar)
        {
            this.RemoveLeft(leftChar);
            this.AddRight(rightChar);
        }

        private void AddRight(char c)
        {
            this.patternHash = (this.patternHash + (c * (powerBase / hashBase)));
            //this.patternHash = ((this.patternHash * this.hashBase) + (c - 'a')) % this.mod;
        }

        private void RemoveLeft(char c)
        {
            this.patternHash = (this.patternHash - c) / this.hashBase;
            //this.patternHash = (this.patternHash - (this.powerBase * (c - 'a'))) / this.hashBase;
        }

        private long GenerateHash(string input, int end)
        {
            long hash = 0;

            for (int i = 0; i < end; i++)
            {
                hash = (hash + (input[i] * this.powerBase)) % this.mod;
                this.powerBase *= this.hashBase;
            }

            return hash;
        }

        public override bool Equals(object obj)
        {
            var otherHash = obj as Hash;

            return otherHash.StringHash == this.StringHash;
        }
    }
}
