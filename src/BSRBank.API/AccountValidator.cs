namespace BSRBank.API
{
    public class AccountValidator
    {
        //public static bool ValidateAccount(string acc)
        //{
        //    if (!acc.StartsWith("PL"))
        //        acc = "PL" + acc;
        //    var countryCode = acc.Substring(0, 2).ToCharArray();
        //    var check = acc.Substring(4) + ( countryCode[0] - 55 ) + ( countryCode[1] - 55 ) + acc.Substring(2, 2);
        //    var intarr = new int[5];
        //    check = check.TrimStart('0');
        //    for ( var i = 0; i < intarr.Length; i++ )
        //    {
        //        if ( i * 6 + 6 < check.Length )
        //            intarr[i] = int.Parse(check.Substring(i * 6, 6));
        //        else
        //            intarr[i] = int.Parse(check.Substring(i * 6));
        //    }
        //    for ( var i = 0; i < intarr.Length; i++ )
        //    {
        //        var mod = intarr[i] % 97;
        //        if ( i >= intarr.Length - 1 )
        //        {
        //            return mod == 1;
        //        }
        //        var next = intarr[i + 1];
        //        var nextString = mod.ToString() + next.ToString();
        //        intarr[i + 1] = int.Parse(nextString);
        //    }
        //    return false;
        //}

        public static bool ValidateAccount(string acc)
        {
            if (acc.Length != 26) return false;
            var check = acc.Substring(2) + acc.Substring(0, 2);
            var intarr = new int[4];
            check = check.TrimStart('0');
            for ( var i = 0; i < intarr.Length; i++ )
            {
                if ( i * 6 + 6 < check.Length )
                    intarr[i] = int.Parse(check.Substring(i * 6, 6));
                else
                    intarr[i] = int.Parse(check.Substring(i * 6));
            }
            for ( var i = 0; i < intarr.Length; i++ )
            {
                var mod = intarr[i] % 97;
                if ( i >= intarr.Length - 1 )
                {
                    return mod == 1;
                }
                var next = intarr[i + 1];
                var nextString = mod.ToString() + next.ToString();
                intarr[i + 1] = int.Parse(nextString);
            }
            return false;
        }
    }
}
