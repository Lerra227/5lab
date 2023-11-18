using System.Collections;


MyList<int> ints = new() { 1,1,2,3,4,5,6,788,7};
MyDictionary<string, int> md = new();
md.Add(new KeyValuePair<string, int>("elem", 1));

foreach(var m in md)
{
    Console.WriteLine(m);
}



public class MyMatrix
{
    int n => matrix.Count;
    int m => matrix[0].Count;
    List<List<double>> matrix;
    public MyMatrix(int m, int n, int low, int top)
    {
        matrix = new List<List<double>>();
        var rand = new Random();
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
            {
                matrix.Add(new List<double>());
                for (int k = 0; k < m; k++)
                {
                    matrix[j].Add(rand.Next(low, top));
                }
            }

    }
   public void Fill(int low, int top)
    {
        var rand = new Random();
        for (int i = 0; i < m; i++)
            for (int j = 0; j < n; j++)
            {
                matrix.Add(new List<double>());
                for (int k = 0; k < m; k++)
                {
                    matrix[j].Add(rand.Next(low, top));
                }
            }
    }

    public void ChangeSize(int mNew, int nNew, int low, int top)
    {
       List<List<double>> NewMatrix = new List<List<double>>(nNew);
        var rand = new Random();
        for (int i = 0; i < mNew; i++)
            for (int j = 0; j < nNew; j++)
            {
                NewMatrix.Add(new List<double>());
                if (i < n && j < m)
                {
                    NewMatrix[i].Add(matrix[i][j]);
                }
                else
                {
                    NewMatrix[i].Add(rand.Next(low, top));
                }
            }
        matrix = NewMatrix;

    }

    public void ShowPartially(int nS, int nF, int mS, int mF)
    {
        for (int i = nS - 1; i < nF; i++)
        {
            for (int j = mS - 1; j < mF; j++)
            {
                Console.Write($"{matrix[i][j]} ");
            }

            Console.WriteLine();
        }
    }

    public void Show()
    {
        foreach (var row in matrix)
        {
            foreach (var num in row)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();
        }
    }

    public double this[int n, int m]
    {
        get => this.matrix[n] [m]; 
        set => this.matrix[n] [m] = value; 
    }
}


public class MyList<T> :IEnumerable<T> 
{
    T[] array;

    public MyList(params T[] array1)
    {
        this.array = array1;
    }

    public void Add(T item)
    {
        var nArray = new T[array.Length + 1];
        array.CopyTo(nArray, 0);
        nArray[array.Length] = item;
        array = nArray;
    }

    public T this[int index] => array[index]; 

    public int size() => array.Length;

    public IEnumerator<T> GetEnumerator()
    {
        return (array as List<T>).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return array.GetEnumerator();
    }
}


class MyDictionary<TKey, TValue> 
{
    List<KeyValuePair<TKey, TValue>> dictionary = new();

    
    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        for (int i = 0; i < dictionary.Count; i++)
        {
            yield return dictionary[i]; 
        }
    }
    
    public IEnumerator<KeyValuePair<TKey, TValue>> GetByKey(TKey key)
    {
        foreach (var pair in dictionary) { 
            if(Equals(pair.Key, key)) yield return pair;
        
        }
    }
  

    public void Add(KeyValuePair<TKey, TValue> pair)
    {
        dictionary.Add(pair);
    }

    public TValue this[TKey key]
    {
        get
        {
            foreach (var pair in dictionary)
            {
                if (Equals(pair.Key, key)) return pair.Value;
            }
            throw new Exception("There are no element in the dictionary with this key");
        }
    }

    int Size() => dictionary.Count;

    
}
