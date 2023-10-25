public class DoublyLinkedList<T>
{
    private DoublyLinkedListNode<T> head;
    private DoublyLinkedListNode<T> tail;
    private int count;

    public int Count { get { return count; } }

    public void AddLast(T data)
    {
        DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T> { Data = data };

        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            newNode.Previous = tail;
            tail = newNode;
        }

        count++;
    }

    public void AddFirst(T data)
    {
        DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T> { Data = data };

        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            newNode.Next = head;
            head.Previous = newNode;
            head = newNode;
        }

        count++;
    }

    public void RemoveLast()
    {
        if (count == 0)
            throw new InvalidOperationException("The list is empty.");

        if (count == 1)
        {
            head = null;
            tail = null;
        }
        else
        {
            tail.Previous.Next = null;
            tail = tail.Previous;
        }

        count--;
    }

    public void RemoveFirst()
    {
        if (count == 0)
            throw new InvalidOperationException("The list is empty.");

        if (count == 1)
        {
            head = null;
            tail = null;
        }
        else
        {
            head.Next.Previous = null;
            head = head.Next;
        }

        count--;
    }

    public void AddAt(int index, T data)
    {
        if (index < 0 || index > count)
            throw new IndexOutOfRangeException();

        if (index == 0)
        {
            AddFirst(data);
            return;
        }

        if (index == count)
        {
            AddLast(data);
            return;
        }

        DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T> { Data = data };
        DoublyLinkedListNode<T> current = head;

        for (int i = 0; i < index; i++)
        {
            current = current.Next;
        }

        newNode.Previous = current.Previous;
        newNode.Next = current;
        current.Previous.Next = newNode;
        current.Previous = newNode;

        count++;
    }

    public T GetAt(int index)
    {
        if (index < 0 || index >= count)
            throw new IndexOutOfRangeException();

        DoublyLinkedListNode<T> current = head;

        for (int i = 0; i < index; i++)
        {
            current = current.Next;
        }

        return current.Data;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= count)
            throw new IndexOutOfRangeException();

        if (index == 0)
        {
            RemoveFirst();
            return;
        }

        if (index == count - 1)
        {
            RemoveLast();
            return;
        }

        DoublyLinkedListNode<T> current = head;

        for (int i = 0; i < index; i++)
        {
            current = current.Next;
        }

        current.Previous.Next = current.Next;
        current.Next.Previous = current.Previous;

        count--;
    }

    public void Clear()
    {
        head = null;
        tail = null;
        count = 0;
    }

    public void ReplaceAt(int index, T data)
    {
        if (index < 0 || index >= count)
            throw new IndexOutOfRangeException();

        DoublyLinkedListNode<T> current = head;

        for (int i = 0; i < index; i++)
        {
            current = current.Next;
        }

        current.Data = data;
    }

    public bool IsEmpty()
    {
        return head == null;
    }

    public void Reverse()
    {
        DoublyLinkedListNode<T> current = head;
        DoublyLinkedListNode<T> temp = null;

        while (current != null)
        {
            temp = current.Previous;
            current.Previous = current.Next;
            current.Next = temp;
            current = current.Previous;
        }

        if (temp != null)
        {
            head = temp.Previous;
        }
    }

    public void InsertListAt(int index, DoublyLinkedList<T> otherList)
    {
        if (index < 0 || index > count)
            throw new IndexOutOfRangeException();

        if (otherList.IsEmpty())
            return;

        if (index == 0)
        {
            otherList.tail.Next = head;
            head.Previous = otherList.tail;
            head = otherList.head;
        }
        else if (index == count)
        {
            tail.Next = otherList.head;
            otherList.head.Previous = tail;
            tail = otherList.tail;
        }
        else
        {
            DoublyLinkedListNode<T> current = head;

            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            otherList.head.Previous = current.Previous;
            otherList.tail.Next = current;
            current.Previous.Next = otherList.head;
            current.Previous = otherList.tail;
        }

        count += otherList.Count;
    }

    public void InsertListAtEnd(DoublyLinkedList<T> otherList)
    {
        if (otherList.IsEmpty())
            return;

        if (IsEmpty())
        {
            head = otherList.head;
            tail = otherList.tail;
        }
        else
        {
            tail.Next = otherList.head;
            otherList.head.Previous = tail;
            tail = otherList.tail;
        }

        count += otherList.Count;
    }

    public void InsertListAtBeginning(DoublyLinkedList<T> otherList)
    {
        if (otherList.IsEmpty())
            return;

        if (IsEmpty())
        {
            head = otherList.head;
            tail = otherList.tail;
        }
        else
        {
            otherList.tail.Next = head;
            head.Previous = otherList.tail;
            head = otherList.head;
        }

        count += otherList.Count;
    }

    public bool ContainsList(DoublyLinkedList<T> otherList)
    {
        if (otherList.IsEmpty())
            return true;

        DoublyLinkedListNode<T> current = head;

        while (current != null)
        {
            if (current.Data.Equals(otherList.head.Data))
            {
                DoublyLinkedListNode<T> currentOther = otherList.head;
                DoublyLinkedListNode<T> currentThis = current;

                while (currentOther != null && currentThis != null && currentOther.Data.Equals(currentThis.Data))
                {
                    currentOther = currentOther.Next;
                    currentThis = currentThis.Next;
                }

                if (currentOther == null)
                    return true;
            }

            current = current.Next;
        }

        return false;
    }

    public int FindFirstList(DoublyLinkedList<T> otherList)
    {
        if (otherList.IsEmpty())
        {
            return -1;
        }

        DoublyLinkedListNode<T> current = head;
        int index = 0;

        while (current != null)
        {
            if (current.Data.Equals(otherList.head.Data))
            {
                DoublyLinkedListNode<T> currentOther = otherList.head;
                DoublyLinkedListNode<T> currentThis = current;

                while (currentOther != null && currentThis != null && currentOther.Data.Equals(currentThis.Data))
                {
                    currentOther = currentOther.Next;
                    currentThis = currentThis.Next;
                }

                if (currentOther == null)
                    return index;
            }

            current = current.Next;
            index++;
        }

        return -1;
    }

    public int FindLastList(DoublyLinkedList<T> otherList)
    {
        if (otherList.IsEmpty()) return -1;
        DoublyLinkedListNode<T> current = tail;
        int index = count - 1;
        while (current != null)
        {
            if (current.Data.Equals(otherList.tail.Data))
            {
                DoublyLinkedListNode<T> currentOther = otherList.tail;
                DoublyLinkedListNode<T> currentThis = current;
                while (currentOther != null && currentThis != null && currentOther.Data.Equals(currentThis.Data))
                {
                    currentOther = currentOther.Previous;
                    currentThis = currentThis.Previous;
                }
                if (currentOther == null) return index;
            }
            current = current.Previous;
            index--;
        }
        return -1;
    }

    public void ExchangeElements(int index1, int index2)
    {
        if (index1 < 0 || index1 >= count || index2 < 0 || index2 >= count) throw new IndexOutOfRangeException();
        if (index1 == index2) return;
        int smallerIndex = Math.Min(index1, index2);
        int largerIndex = Math.Max(index1, index2);
        DoublyLinkedListNode<T> node1 = GetNodeAt(smallerIndex);
        DoublyLinkedListNode<T> node2 = GetNodeAt(largerIndex);
        T temp = node1.Data;
        node1.Data = node2.Data;
        node2.Data = temp;
    }

    private DoublyLinkedListNode<T> GetNodeAt(int index)
    {
        if (index < 0 || index >= count) throw new IndexOutOfRangeException();
        DoublyLinkedListNode<T> current = head;
        for (int i = 0; i < index; i++)
        {
            current = current.Next;
        }
        return current;
    }

    public void PrintList()
    {
        DoublyLinkedListNode<T> current = head;

        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }

        Console.WriteLine();
    }
}
