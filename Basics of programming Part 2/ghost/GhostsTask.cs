using System;
using System.Security.Cryptography;
using System.Text;

namespace hashes;

public class GhostsTask : 
	IFactory<Document>, IFactory<Vector>, IFactory<Segment>, IFactory<Cat>, IFactory<Robot>, 
	IMagic
{


	Cat NewCat { get; set; }
	Robot NewRobot { get; set; }
	Vector NewVector  { get; set; }
	Segment NewSegment { get; set; }

	Document NewDocument { get; set; }
	//string EncodingString { get; set; }
    //string DocumentTitle { get; set; }
    byte[] NewBytes { get; set; }

    public void DoMagic()
	{
		if(NewCat!=null)
			NewCat.Rename("Pusia");
		if(NewRobot!=null)
			Robot.BatteryCapacity = 200;
		if (NewVector != null)
			NewVector.Add(new Vector(1, 2));
		if(NewSegment!=null)
			NewSegment.Start.Add(new Vector(1, 2));
		if (NewDocument != null)
		{
			for (int i = 0;i<NewBytes.Length;i++)
				NewBytes[i] = 222;
        }
    }



	// Чтобы класс одновременно реализовывал интерфейсы IFactory<A> и IFactory<B> 
	// придется воспользоваться так называемой явной реализацией интерфейса.
	// Чтобы отличать методы создания A и B у каждого метода Create нужно явно указать, к какому интерфейсу он относится.
	// На самом деле такое вы уже видели, когда реализовывали IEnumerable<T>.

	Document IFactory<Document>.Create()
	{
        if (NewDocument == null)
        {
			var documentTitle = "Title1";
			var newEncoding = Encoding.ASCII;
            var encodingString = "sdsdasdadasdsadsaddrtt121231243 as";
            NewBytes = newEncoding.GetBytes(encodingString);
            NewDocument = new Document(documentTitle, newEncoding, NewBytes);
        }
        return NewDocument;
    }

    Vector IFactory<Vector>.Create()
	{
		if (NewVector == null)
			NewVector = new Vector(0, 2);
		return NewVector;
	}

	Segment IFactory<Segment>.Create()
	{
		if (NewSegment == null)
			NewSegment = new Segment(new Vector(1, 1), new Vector(2, 2));
		return NewSegment;
	}

    Cat IFactory<Cat>.Create()
    {

        if (NewCat == null)
			NewCat = new Cat("Nyashka", "cool", new DateTime(2023, 8, 25));
        return NewCat;

    }

    Robot IFactory<Robot>.Create()
    {
		if (NewRobot == null)
            NewRobot = new Robot("1", 100);
		return NewRobot;
    }

    // И так даллее по аналогии...
}