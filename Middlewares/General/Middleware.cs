namespace PathonDB.Middlewares.General {
    public abstract class Middleware {
        private Middleware next = null;

        public Middleware LinkWith(Middleware next) {
            this.next = next;
            return next;
        }

        public abstract bool Check(string query);

        protected bool CheckNext(string query) {
            if(next == null) return true;

            return next.Check(query);
        }
    }
}