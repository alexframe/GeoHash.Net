namespace GeoHash.Net.Utilities.Enums
{
    public enum GeoHashPrecision
    {
        /// <summary>
        /// ~ 5,004km x 5,004km
        /// </summary>
        MinimumPrecision = Level1,

        /// <summary>
        /// ~ 5,004km x 5,004km
        /// </summary>
        Level1 = 1,

        /// <summary>
        /// ~ 1,251km x 625km
        /// </summary>
        Level2 = 2,

        /// <summary>
        /// ~ 156km x 156km
        /// </summary>
        Level3 = 3,

        /// <summary>
        /// ~ 39km x 19.5km
        /// </summary>
        Level4 = 4,

        /// <summary>
        /// ~ 4.9km x 4.9km
        /// </summary>
        Level5 = 5,

        /// <summary>
        /// ~ 1.2km x 0.61km
        /// </summary>
        Level6 = 6,

        /// <summary>
        /// ~ 152.8m x 152.8m
        /// </summary>
        Level7 = 7,

        /// <summary>
        /// ~ 38.2m x 19.1m
        /// </summary>
        Level8 = 8,

        /// <summary>
        /// ~ 4.78m x 4.78m
        /// </summary>
        Level9 = 9,

        /// <summary>
        /// ~ 1.19m x 0.60m
        /// </summary>
        Level10 = 10,

        /// <summary>
        /// ~ 14.9cm x 14.9cm
        /// </summary>
        Level11 = 11,

        /// <summary>
        /// ~ 3.7cm x 1.8cm
        /// </summary>
        Level12 = 12,

        /// <summary>
        /// ~ 3.7cm x 1.8cm
        /// </summary>
        MaximumPrecision = Level12
    }
}
