using System;

namespace B1 {
    public class ApiKeys {
        protected static string XyzKey { get; } = "fagfwfw6445jfefefe";
    }
    public class UseApi: ApiKeys {
        private static int Count { get; set; } = 0;
        private static void ClearCount() {
            Count = 0;
            return;
        }
        public static string XyzApi() {
            Count++;
            return XyzKey;
        }
        public static void ClearApiCache() { ClearCount(); }
        public static int GetCount() { return Count; }
    }
}