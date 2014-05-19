using System;

namespace ConsoleApplication1 {
    class TravelAroundWorld {
        public static void MainTravelAroundWorld(string[] args) {
            var cityAndCapacity = Console.ReadLine().Split(' ');
            var numberOfCities = long.Parse(cityAndCapacity[0]);
            var tankCapacity = long.Parse(cityAndCapacity[1]);
            long[] fuelAvailableByCity = new long[numberOfCities];
            long[] fuelRequiredBetweenCities = new long[numberOfCities];

            var fuelAvailableByCityInput = Console.ReadLine().Split(' ');
            var fuelRequiredBetweenCitiesInput = Console.ReadLine().Split(' ');
            if (fuelAvailableByCityInput.Length == numberOfCities && fuelRequiredBetweenCitiesInput.Length == numberOfCities) {
                for (long count = 0; count < fuelAvailableByCityInput.Length; count++) {
                    fuelAvailableByCity[count] = long.Parse(fuelAvailableByCityInput[count]);
                    fuelRequiredBetweenCities[count] = long.Parse(fuelRequiredBetweenCitiesInput[count]);
                }
                Console.WriteLine(CountCities(numberOfCities, tankCapacity, fuelAvailableByCity, fuelRequiredBetweenCities));
                Console.ReadLine();
            }
        }

        private static long CountCities(long numberOfCities, long tankCapacity, long[] fuelAvailableByCity, long[] fuelRequiredBetweenCities) {
            long qualifiedCities = 0;
            for (long startCityIndex = 0; startCityIndex < numberOfCities; startCityIndex++) {
                // index + 1 through n - 1 and 0 through index
                var currentCityIndex = startCityIndex;
                var nextCityIndex = (currentCityIndex + 1) % (numberOfCities);
                var currentTankCapacity = fuelAvailableByCity[currentCityIndex];
                if (currentTankCapacity > tankCapacity) currentTankCapacity = tankCapacity;
                for (long numberOfCitiesTravelled = 0; numberOfCitiesTravelled < numberOfCities; numberOfCitiesTravelled++) {
                    currentTankCapacity -= fuelRequiredBetweenCities[currentCityIndex];
                    if (currentTankCapacity < 0) break;
                    if (nextCityIndex == startCityIndex) {
                        qualifiedCities += 1;
                        break;
                    }
                    currentCityIndex = nextCityIndex;
                    nextCityIndex = (nextCityIndex + 1) % (numberOfCities);
                    currentTankCapacity += fuelAvailableByCity[currentCityIndex];
                    if (currentTankCapacity > tankCapacity) currentTankCapacity = tankCapacity;
                }
            }
            return qualifiedCities;
        }
    }
}
