    function getSolutionCominations()
    {
        var Combinations = 
            [
            "GDFFXGGFGFAFGFGGDDFFFFXXFGFDFGFGFDFGFFFDGGAAFGGFDXFXXFGFXFDXFFFAGGAF",
            "GDFXGFGFGAFFGFGDDGFFFXXFFGFFGDFGFFGDFFFGGDAAFGFGDXFXFXGFXDXFFFFGGAAF",
            "GDFFXGGFFGAFGFGGDDFFFFXXFGDFFGFGDFFGFFDFGGAAGFGFDXXFXFGFFXDXFFAFGGAF",
            "GDXFGFGFAGFFGFDGDGFFXFXFFGFFGDFGFFGDFFGFGDAAGFFGDXXFFXGFDXXFFFGFGAAF",
            "GDXGFFGFAFFGGFDDGGFFXXFFFGFGDFFGFGDFFFGGDFAAGFGFDXXFXFGFDXFXFFGGAFAF",
            "GDFGXFGFFFAGGFGDDGFFFXXFFGDGFFFGDGFFFFDGGFAAGFGFDXXFXFGFFXDXFFAGGFAF",
            "DGFXGFFGGAFFFGGDDGFFFXXFGFFFGDGFFFGDFFFGGDAAFGFGXDFXFXFGXDXFFFFGGAFA",
            "GDFGXFGFGFAFGFGDDGFFFXXFFGFGFDFGFGFDFFFGGDAAFFGGDXFFXXGFXXDFFFFGGAAF",
            "GDGXFFGFFAFGGFDDGGFFXXFFFGGFDFFGGFDFFFGGDFAAFGGFDXFXXFGFXDFXFFGGAFAF",
            "GDFGFXGFFFGAGFGDGDFFFXFXFGDGFFFGDGFFFFDGFGAAGFFGDXXFFXGFFXXDFFAGFGAF",
            "DGGXFFFGFAFGFGDDGGFFXXFFGFGFDFGFGFDFFFGGDFAAFGGFXDFXXFFGXDFXFFGGAFFA",
            "GDFXFGGFFAGFGFGDGDFFFXFXFGDFFGFGDFFGFFDGFGAAGGFFDXXXFFGFFDXXFFAGFGAF",
            "GDFXFGGFGAFFGFGDGDFFFXFXFGFFDGFGFFDGFFFGDGAAFGGFDXFXXFGFXDFXFFFGAGAF",
            "GDFFGXGFGFFAGFGGDDFFFFXXFGFDGFFGFDGFFFFDGGAAFGFGDXFXFXGFXFXDFFFAGGAF",
            "GDFFGXGFFGFAGFGGDDFFFFXXFGDFGFFGDFGFFFDFGGAAGFFGDXXFFXGFFXXDFFAFGGAF",
            "GDGXFFGFFAGFGFDDGGFFXXFFFGGFFDFGGFFDFFGGFDAAFGFGDXFXFXGFXDXFFFGGFAAF",
            "GDGFFXGFFFGAGFDGGDFFXFFXFGGDFFFGGDFFFFGDFGAAFGFGDXFXFXGFXFXDFFGAFGAF",
            "GDXFGFGFAFFGGFDGDGFFXFXFFGFDGFFGFDGFFFGDGFAAGGFFDXXXFFGFDFXXFFGAGFAF",
            "DGFFXGFGGFAFFGGGDDFFFFXXGFFDFGGFFDFGFFFDGGAAFGGFXDFXXFFGXFDXFFFAGGFA",
            "DGFXFGFGGAFFFGGDGDFFFXFXGFFFDGGFFFDGFFFGDGAAFGGFXDFXXFFGXDFXFFFGAGFA",
            "DGGFFXFGFGFAFGDGGDFFXFFXGFGFDFGFGFDFFFGFDGAAFFGGXDFFXXFGXXFDFFGFAGFA",
            "DGGXFFFGFAGFFGDDGGFFXXFFGFGFFDGFGFFDFFGGFDAAFGFGXDFXFXFGXDXFFFGGFAFA",
            "DGXFFGFGAFGFFGDGGDFFXFFXGFFDFGGFFDFGFFGDFGAAGGFFXDXXFFFGDFXXFFGAFGFA",
            "DGGFXFFGFFAGFGDGDGFFXFXFGFGDFFGFGDFFFFGDGFAAFGGFXDFXXFFGXFDXFFGAGFFA",
            "DGXGFFFGAFGFFGDDGGFFXXFFGFFGFDGFFGFDFFGGFDAAGFFGXDXFFXFGDXXFFFGGFAFA",
            "DGXFFGFGAGFFFGDGGDFFXFFXGFFFDGGFFFDGFFGFDGAAGFGFXDXFXFFGDXFXFFGFAGFA",
            "DGXFGFFGAGFFFGDGDGFFXFXFGFFFGDGFFFGDFFGFGDAAGFFGXDXFFXFGDXXFFFGFGAFA",
            "DGXGFFFGAFFGFGDDGGFFXXFFGFFGDFGFFGDFFFGGDFAAGFGFXDXFXFFGDXFXFFGGAFFA",
            "DGXFGFFGAFFGFGDGDGFFXFXFGFFDGFGFFDGFFFGDGFAAGGFFXDXXFFFGDFXXFFGAGFFA",
            "GDGFFXGFFGFAGFDGGDFFXFFXFGGFDFFGGFDFFFGFDGAAFFGGDXFFXXGFXXFDFFGFAGAF",
            "GDGFXFGFFGAFGFDGDGFFXFXFFGGFFDFGGFFDFFGFGDAAFFGGDXFFXXGFXXDFFFGFGAAF",
            "GDFGFXGFGFFAGFGDGDFFFXFXFGFGDFFGFGDFFFFGDGAAFFGGDXFFXXGFXXFDFFFGAGAF",
            "GDXFFGGFAFGFGFDGGDFFXFFXFGFDFGFGFDFGFFGDFGAAGGFFDXXXFFGFDFXXFFGAFGAF",
            "GDXGFFGFAFGFGFDDGGFFXXFFFGFGFDFGFGFDFFGGFDAAGFFGDXXFFXGFDXXFFFGGFAAF",
            "GDGFXFGFFFAGGFDGDGFFXFXFFGGDFFFGGDFFFFGDGFAAFGGFDXFXXFGFXFDXFFGAGFAF",
            "GDFXGFGFFAFGGFGDDGFFFXXFFGDFGFFGDFGFFFDGGFAAGGFFDXXXFFGFFDXXFFAGGFAF",
            "DGFFXGFGFGAFFGGGDDFFFFXXGFDFFGGFDFFGFFDFGGAAGFGFXDXFXFFGFXDXFFAFGGFA",
            "DGFGXFFGGFAFFGGDDGFFFXXFGFFGFDGFFGFDFFFGGDAAFFGGXDFFXXFGXXDFFFFGGAFA",
            "DGFGFXFGFFGAFGGDGDFFFXFXGFDGFFGFDGFFFFDGFGAAGFFGXDXFFXFGFXXDFFAGFGFA",
            "DGFGFXFGGFFAFGGDGDFFFXFXGFFGDFGFFGDFFFFGDGAAFFGGXDFFXXFGXXFDFFFGAGFA",
            "DGGFXFFGFGAFFGDGDGFFXFXFGFGFFDGFGFFDFFGFGDAAFFGGXDFFXXFGXXDFFFGFGAFA",
            "DGGFFXFGFFGAFGDGGDFFXFFXGFGDFFGFGDFFFFGDFGAAFGFGXDFXFXFGXFXDFFGAFGFA",
            "DGFFGXFGFGFAFGGGDDFFFFXXGFDFGFGFDFGFFFDFGGAAGFFGXDXFFXFGFXXDFFAFGGFA",
            "DGFXFGFGFAGFFGGDGDFFFXFXGFDFFGGFDFFGFFDGFGAAGGFFXDXXFFFGFDXXFFAGFGFA",
            "GDXFFGGFAGFFGFDGGDFFXFFXFGFFDGFGFFDGFFGFDGAAGFGFDXXFXFGFDXFXFFGFAGAF",
            "DGFXGFFGFAFGFGGDDGFFFXXFGFDFGFGFDFGFFFDGGFAAGGFFXDXXFFFGFDXXFFAGGFFA",
            "DGFFGXFGGFFAFGGGDDFFFFXXGFFDGFGFFDGFFFFDGGAAFGFGXDFXFXFGXFXDFFFAGGFA",
            "DGFGXFFGFFAGFGGDDGFFFXXFGFDGFFGFDGFFFFDGGFAAGFGFXDXFXFFGFXDXFFAGGFFA"
            ];
        return Combinations;
    }

    function DecodeKeySquare(KeySquare)
    {
        var Combinations = getSolutionCominations();
        var DecodedResults = new Array(Combinations.length);

        for (x=0; x<Combinations.length; x++)
        {
            DecodedString = MapPairs(KeySquare, Combinations[x]);
            DecodedResults[x] = DecodedString; 
        }

        return DecodedResults;
    }

    function MapPairs(KeySquare, Combination)
    {
        var ReturnString = "";
        for (y = 0; y < Combination.length; y += 2)
        {
            var CurrentPair = Combination.substr(y, 2);
            ReturnString += KeySquare.substr((getGridValue(CurrentPair) -1), 1);
        }
        return ReturnString;
    }

    function getGridValue(Pair)
    {
        var PairValue = 0;
        switch(Pair)
        {
            //Row A
            case "AA":
                PairValue = 1;
                break;
            case "AD":
                PairValue = 2;
                break;
            case "AF":
                PairValue = 3;
                break;
            case "AG":
                PairValue = 4;
                break;
            case "AX":
                PairValue = 5;
                break;

            //Row D
            case "DA":
                PairValue = 6;
                break;
            case "DD":
                PairValue = 7;
                break;
            case "DF":
                PairValue = 8;
                break;
            case "DG":
                PairValue = 9;
                break;
            case "DX":
                PairValue = 10;
                break;
            
                //Row F
            case "FA":
                PairValue = 11;
                break;
            case "FD":
                PairValue = 12;
                break;
            case "FF":
                PairValue = 13;
                break;
            case "FG":
                PairValue = 14;
                break;
            case "FX":
                PairValue = 15;
                break;

            //Row G
            case "GA":
                PairValue = 16;
                break;
            case "GD":
                PairValue = 17;
                break;
            case "GF":
                PairValue = 18;
                break;
            case "GG":
                PairValue = 19;
                break;
            case "GX":
                PairValue = 20;
                break;
            
            //Row X
            case "XA":
                PairValue = 21;
                break;
            case "XD":
                PairValue = 22;
                break;
            case "XF":
                PairValue = 23;
                break;
            case "XG":
                PairValue = 24;
                break;
            case "XX":
                PairValue = 25;
                break;
        }
        return PairValue;
    }


    function GenerateKeySquares(EntryPos, EntryKey, StartPos, Iterations)
    {
        EntryPos = parseInt(EntryPos);
        StartPos = parseInt(StartPos);
        Iterations = parseInt(Iterations);

        var KeyMap = EntryKey.split('|');
        for (j=0; j<KeyMap.length;j++)
        {
            KeyMap[j] = parseInt(KeyMap[j]);
        }

        var KeySquares = Array();
        var Difference = StartPos - EntryPos;
        console.log('I need to calculate ' + (Iterations + Difference) + ' keysquares. I need to skip ' + Difference);

        for (i = 1; i <= (Iterations + Difference); i++)
        {
            console.log('(' + i + '/' + (Iterations + Difference) + ') Start');
            KeyMap = IncrementPosition(KeyMap);
            if (i > Difference)
            {   
                KeySquares.push(TranslateCharMap(KeyMap));
            }
        }
        return KeySquares;        
    }

    function IncrementPosition(KeyMap)
    {
        var TempMapping = KeyMap.slice(0);
        TempMapping.pop();

        var NewChar = KeyMap[KeyMap.length-1] + 1;
        while (ArrayContains(TempMapping, NewChar) || NewChar > 25)
        {
            NewChar++;
            if (NewChar > 25)
            {
                TempMapping = IncrementPosition(TempMapping);
                NewChar = 1;
            }
        }
        TempMapping.push(NewChar);
        return TempMapping;
    }

    function ArrayContains(a, Value)
    {
        var x = a.length;
        while (x--) {
            if (a[x] === Value) {
                return true;
            }
        }
        return false;
    }

    function TranslateCharMap(CharMap)
    {
        var Output = "";
        var Offset = 0;
        for (y=0; y<CharMap.length;y++)
        {
            if (y > 9) Offset = 1;
            Output += String.fromCharCode(64 + CharMap[y] + Offset);
        }
        return Output;
    }