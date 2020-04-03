# BlackScholesOptionsPricer

Options pricer GUI in C#, capable of calculating the price of European call or put options using the Black-Scholes pricing model.

The Black-Scholes pricing model takes the following input parameters:
```
S	Stock price
K	Strike price
t	Time to maturity in years
σ	Standard deviation of underlying stock
r	Risk-free interest rate
```

Based on these parameters, define the values d_1 and d_2 as follows:
```
d_1=  ( ln⁡(S/K)+(r+ σ^2/2)t)/(σ√t)
d_2=d_1-σ√t
```

The premiums for a call option c and a put option p are then calculated as follows:
```
c=SN(d_1 )-Ke^(-rt) N(d_2)
p=Ke^(-rt) N(-d_2 )-SN(-d_1)
```
Where N is the cumulative normal distribution function.
