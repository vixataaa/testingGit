#include <iostream>
#include <string>
#include <algorithm>
using namespace std;

int GetMin (int a, int b)
{
    return a < b ? a : b;
}

int Decompose(string sentence, string* validWords, int numValidWords)
{
    int N = sentence.size();
    int M = numValidWords;
    string* validSorted = new string[M];
    for (int i = 0; i < M; i++)
    {
        string c = string(validWords[i]);
        sort (&c[0], &c[0] + c.size());

        validSorted[i] = string(c);
    }
    int* min = new int[N + 1];
    min[0] = 0;
    for (int i = 0; i < N; i++)
    {
        min[i + 1] = 999999;
    }
    for (int i = 0; i < N; i++)
    {
        for (int j = 0; j < M; j++)
        {
            if (i + 1 >= validWords[j].size())
            {
                string s = sentence.substr(i - validWords[j].size() + 1, validWords[j].size());
                string c = string(s);
                sort (&c[0], &c[0] + c.size());
                string s2 = string(c);
                if (s2 == validSorted[j])
                {
                    int cost = 0;
                    for (int k = 0; k < validWords[j].size(); k++)
                    {
                        if (s[k] != validWords[j][k]) cost++;
                    }
                    min[i + 1] = GetMin(min[i + 1], min[i + 1 - validWords[j].size()] + cost);
                }
            }
        }
    }
    return min[N] < 999999 ? min[N] : -1;
}

int main()
{
    string sentence;
    cin >> sentence;
    int numValidWords;
    cin >> numValidWords;

    string * validWords = new string [numValidWords];

    for (int i=0; i<numValidWords; i++)
    {
        cin>>validWords[i];
    }

    cout<<Decompose(sentence, validWords, numValidWords)<<endl;
}
