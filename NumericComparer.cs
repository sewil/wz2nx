namespace System
{
    [Serializable]
    public class NumericComparer : StringComparer
    {
        public override int Compare(string x, string y)
        {
            if ((object)x == y)
            {
                return 0;
            }

            if (x == null)
            {
                return -1;
            }

            if (y == null)
            {
                return 1;
            }

            var cX = int.TryParse(x, out int nX);
            var cY = int.TryParse(y, out int nY);
            if (cX && !cY)
            {
                return -1;
            }
            else if (!cX && cY)
            {
                return 1;
            }
            else if (cX && cY)
            {
                return nX > nY ? 1 : nX == nY ? 0 : -1;
            }

            return string.CompareOrdinal(x, y);
        }

        public override bool Equals(string x, string y)
        {
            if ((object)x == y)
            {
                return true;
            }

            if (x == null || y == null)
            {
                return false;
            }

            return x.Equals(y);
        }

        public override int GetHashCode(string obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }

            return obj.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is NumericComparer numericComparer))
            {
                return false;
            }

            return this == numericComparer;
        }

        public override int GetHashCode()
        {
            string text = "NumericComparer";
            int hashCode = text.GetHashCode();
            return hashCode;
        }
    }
}
