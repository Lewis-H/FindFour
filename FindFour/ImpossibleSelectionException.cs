using System;

namespace FindFour {
    public class ImpossibleSelectionException : Exception {
        public ImpossibleSelectionException() : base() {
        }

        public ImpossibleSelectionException(string message) : base(message) {
        }

        public ImpossibleSelectionException(string message, Exception inner) : base(message, inner) {
        }
    }
}

