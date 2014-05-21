Tap
===

Convenient combinator-ish things and useful not-very-monadic extension methods.

I uploaded it quickly so it might need a better name, and some of the methods might need better names.

These are all extension methods on a generic type so they can be used anywhere, just remember to put

    using Tap;

T T.Tap(T => void)
------------------

Inject a lambda into a dot chain.

Let's say we have

    new GameObject().AddComponent<StarElf>().BlessedBe();
    
but we forgot to first make her a vampyre ~ (half). We could break up the dot chain into

    StarElf mLady = new GameObject().AddComponent<StarElf>();
    mLady.vampyre = 0.5f;
    mLady.BlessedBe();
    
but that's a lot of typing and saving of variables for a one off joke. Using Tap we can write it as

    new GameObject().AddComponent<StarElf>().Tap(mLady => mLady.vampyre = 0.5f).BlessedBe();
    
T T.Log()
---------

The most common way to use Tap is for quick debugging in the middle of an existing dot chain. Lets say we've built an advanced spy satelite capable of spanking a very specific person but we think we might have the street wrong

    earth.country.state.city.street.house.husband.Spank();
    // BUG: expected husband isn't getting spanked for some reason

We could put a Debug.Log in a tap like this

    earth.country.state.city.street.Tap(street => Debug.Log(street)).house.husband.Spank();

But this is so common that I made it its own method

    earth.country.state.city.street.Log().house.husband.Spank();
    // we find out we've accidentally been spanking the old gentleman on the next block over's husband.

S T.AndAnd(T => S)
------------------

This is like the opposite of the [coalescing](http://msdn.microsoft.com/en-us/library/ms173224.aspx) operator. It only performs the lambda on the right if the expression on the left is non-null.

It's pretty common in unity to only do something if a component exists. It's usually done like this.

    PolaroidPicture picture = GetComponent<PolaroidPicture>();
    
    if (picture != null) {
      picture.ShakeIt();
    }
    
That can get repetative if you do it a lot, so using AndAnd (stolen from http://andand.rubyforge.org/) we can just say

    GetComponent<PolaroidPicture>().AndAnd(picture => picture.ShakeIt());
    
which I think looks popular and cutest.
