public class PrioQueue<T> {
    private int neff;
    private List<ElPrioQueue<T>> queue;

    public PrioQueue(){
        this.neff = 0;
        this.queue = new List<ElPrioQueue<T>>();
    }

    public void Enqueue(ElPrioQueue<T> el){
        if(this.neff == 0){
            this.queue.Add(el);
            this.neff++;
        } else {
            for(int i = this.neff - 1; i >= 0; i--){
                if(el.getPriority() >= this.queue.ElementAt(i).getPriority()){
                    this.queue.Insert(i + 1, el);
                    this.neff++;
                    return;
                }
            }
            this.queue.Insert(0, el);
            this.neff++;
        }
    }

    public T Dequeue(){
        if(this.neff > 0){
            this.neff--;
            ElPrioQueue<T> el = this.queue.First();
            this.queue.RemoveAt(0);
            return el.getCoor();
        } else {
            throw new Exception("Queue sudah kosong");
        }
    }

    public void Clear(){
        this.neff = 0;
        this.queue.Clear();
    }

    public int getNeff(){
        return this.neff;
    }

    public List<ElPrioQueue<T>> getQueue(){
        return this.queue;
    }
}

public class ElPrioQueue<T> {
    private T coor;
    private int priority;

    public ElPrioQueue(T coor, int priority){
        this.coor = coor;
        this.priority = priority;
    }

    public int getPriority(){
        return this.priority;
    }

    public T getCoor(){
        return this.coor;
    }
}