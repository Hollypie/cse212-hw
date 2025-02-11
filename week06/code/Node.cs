public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1
        if (value == this.Data)
        {
            return;
        }

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        if (value == this.Data)
        {
            return true;
        }
        
        // check left
        if (value < this.Data)
        {
            if (this.Left == null)
            {
                return false;
            }
            else
            {
                return this.Left.Contains(value);
            }
            
            
        }
        // check right
        if (value > this.Data)
        {   
            if (this.Right == null)
            {
                return false;
            }
            else
            {
                return this.Right.Contains(value);
            }
        }

        else 
        {
            return false;
        }
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        
        if ( Left == null && Right == null )
        {
            return 1;
        }
        else 
        {
            
            int leftHeight = Left?.GetHeight() ?? 0;
            int rightHeight = Right?.GetHeight() ?? 0;

            return Math.Max(leftHeight, rightHeight) + 1;
         }
            
        // return 0; // Replace this line with the correct return statement(s)
    }
}