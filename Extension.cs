namespace PathonDB {
    public static class Extension {
        public static string RemoveLastChar(this string str) {
            if(str.Length == 0) return "";
            
            return str.Remove(str.Length - 1);
        }
    }
}