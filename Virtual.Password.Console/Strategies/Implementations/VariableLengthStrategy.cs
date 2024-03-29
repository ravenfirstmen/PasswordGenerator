﻿using Virtual.Password.Console.Random;

namespace Virtual.Password.Console.Strategies.Implementations;

public class VariableLengthStrategy : ILengthStrategy
{
    public const int DEFAULT_MAX_PASSWORD_LENGTH = 20;
    public const int DEFAULT_MIN_PASSWORD_LENGTH = FixedLengthStrategy.DEFAULT_PASSWORD_LENGTH;

    private readonly int _maxLength;
    private readonly int _minLength;

    private readonly IRandomGenerator<int> _randomGenerator =
        RandomGeneratorFactory.Create();

    public VariableLengthStrategy(int minLength, int maxLength)
    {
        _minLength = minLength;
        _maxLength = maxLength;
    }

    public VariableLengthStrategy()
        : this(DEFAULT_MIN_PASSWORD_LENGTH, DEFAULT_MAX_PASSWORD_LENGTH)
    {
    }

    #region ILengthStrategy Members

    public int Max => _randomGenerator.GenerateBetween(_minLength, _maxLength);

    #endregion
}