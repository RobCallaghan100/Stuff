﻿namespace GraphicalEditorTests
{
    using System;
    using GraphicalEditor;
    using NUnit.Framework;

    [TestFixture]
    public class CommandArgumentsParserTests    
    {
        private CommandArgumentParser _commandArgumentParser;

        [SetUp]
        public void Setup()
        {
            _commandArgumentParser = new CommandArgumentParser();
        }

        [TearDown]
        public void Teardown()
        {
            _commandArgumentParser = null;
        }

        [TestCase("")]
        [TestCase(" ")]
        public void ShouldShowCommandTypeAsNoneIfGivenEmptyString(string line)
        {
            _commandArgumentParser.Parse(line);

            Assert.That(_commandArgumentParser.CommandType, Is.EqualTo(CommandType.None));
        }

        [TestCase("X")]
        [TestCase("x")]
        [TestCase(" x")]
        [TestCase("x ")]
        public void ShouldShowCommandTypeAsExitWhenGivenX(string line)
        {
            _commandArgumentParser.Parse(line);

            Assert.That(_commandArgumentParser.CommandType, Is.EqualTo(CommandType.Exit));
        }

        [TestCase("x 1")]
        [TestCase("x d")]
        [TestCase("x 11 12")]
        public void ShouldRaiseExceptionIfNotOnlyGivenX(string line)
        {
            var exception = Assert.Throws<ArgumentException>(() => _commandArgumentParser.Parse(line));

            Assert.That(exception.Message, Is.EqualTo("Exit command is only expecting 1 argument eg 'X'"));
        }

        [TestCase("I 1 1", CommandType.Create, 1, 1)]
        [TestCase("I 250 250", CommandType.Create, 250, 250)]
        public void ShouldShowCommandTypeAsCreateWhenGivenIAndGetMAndNValues(string line, CommandType expectedCommandType, int expectedM, int expectedN)
        {
            _commandArgumentParser.Parse(line);

            Assert.That(_commandArgumentParser.CommandType, Is.EqualTo(expectedCommandType));
            Assert.That(_commandArgumentParser.M, Is.EqualTo(expectedM));
            Assert.That(_commandArgumentParser.N, Is.EqualTo(expectedN));
        }

        // TODO: pass in rubbish that is not in our commands, such as "Q x h" etc
    }
}
