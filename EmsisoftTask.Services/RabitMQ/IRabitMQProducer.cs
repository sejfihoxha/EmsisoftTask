namespace EmsisoftTask.Services.RabitMQ
{
    public interface IRabitMQProducer
    {
        void SendProductMessage<T>(T message);
    }
}
