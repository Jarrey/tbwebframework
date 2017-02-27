namespace AspComet.Eventing
{
    /// <summary>
    ///     Raised when a client is publishing a message to the comet message bus
    /// </summary>
    public class ConnectingEvent : CancellableEvent
    {
        private Message[] message;

        /// <summary>
        ///     Initialises a new instance of the <see cref="PublishingEvent"/> class
        /// </summary>
        /// <param name="message"></param>
        public ConnectingEvent(Message[] message)
        {
            this.message = message;
        }

        /// <summary>
        ///     Gets the message being published
        /// </summary>
        public Message[] Message
        {
          get { return this.message; }
          set { this.message = value; }
        }
    }
}
