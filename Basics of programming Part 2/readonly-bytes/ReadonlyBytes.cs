using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace hashes
{
    public class ReadonlyBytes //: IEnumerable
    {
        public byte[] Array { get; }
        public int Length
        {
            get { return Array.Length; }
        }
        readonly int hashCode;
        public ReadonlyBytes(params byte[] array)
        {
            if (array != null)
            {
                Array = array;

                var offsetBasis = unchecked((int)14695981039346656037);
                var prime = unchecked((int)1099511628211);

                var hash = offsetBasis;
                foreach (var item in Array)
                {
                    hash = unchecked((int)hash * prime);
                    hash = unchecked((int)hash ^ item);
                }
                hashCode = hash;
            }
            else
                throw new ArgumentNullException();
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                return this.hashCode == obj.GetHashCode();
            }
        }

        public override int GetHashCode()
        {
            return hashCode;
        }

        public byte this[int index]
        {
            get
            {
                if (index < 0 || index >= Length) throw new IndexOutOfRangeException();
                return Array[index];
            }
        }

        public IEnumerator<byte> GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
                yield return Array[i];
        }

        public void Add(byte value)
        {
            if (Length == Array.Length)
                Enlarge(Array);
            this.Array[Length + 1] = value;
        }

        void Enlarge(params byte[] arr)
        {
            System.Array.Resize(ref arr, Length + 1);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string s = string.Join(", ", Array);
            sb.Append("[").Append(s).Append("]");
            return sb.ToString();
        }
    }
}