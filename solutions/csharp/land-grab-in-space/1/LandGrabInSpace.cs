public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public double Distance(Coord other)
    {
        int deltaX = this.X - other.X;
        int deltaY = this.Y - other.Y;
        return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
    }
    public ushort X { get; }
    public ushort Y { get; }
}

public struct Plot
{
    public Plot(Coord northWest, Coord northEast, Coord southEast, Coord southWest)
    {
        NW = northWest;
        NE = northEast;
        SE = southEast;
        SW = southWest;
    }

    public Coord NW { get; }
    public Coord NE { get; }
    public Coord SE { get; }
    public Coord SW { get; }
}


public class ClaimsHandler
{
    List<Plot> allClaims = new List<Plot>();

    public void StakeClaim(Plot plot) => allClaims.Add(plot);

    public bool IsClaimStaked(Plot plot) => allClaims.IndexOf(plot) != -1;

    public bool IsLastClaim(Plot plot) => plot.Equals(allClaims[^1]);

    public Plot GetClaimWithLongestSide()
    {
        Plot longest = allClaims[0];
        double longestSide = 0.0;
        foreach (Plot p in allClaims)
        {
            List<double> sides = new List<double>();
            sides.Add(p.NW.Distance(p.NE));
            sides.Add(p.NE.Distance(p.SE));
            sides.Add(p.SE.Distance(p.SW));
            sides.Add(p.SW.Distance(p.NW));
            if (sides.Max() > longestSide)
            {
                longest = p;
                longestSide = sides.Max();

            }
        }
        return longest;
    }
}
