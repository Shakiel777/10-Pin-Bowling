﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;


[TestFixture]
public class ActionMasterTest
{
    private ActionMaster actionMaster;
    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private ActionMaster.Action reset = ActionMaster.Action.Reset;
    
    [SetUp]
    public void Setup()
    {
        // ActionMaster actionMaster = new ActionMaster();
        actionMaster = new ActionMaster();
    }

    [Test]
    public void T00PassingTest()
    {
        Assert.AreEqual(1, 1);
    }
    [Test]
    public void T01OneStrikeReturnsEndTurn()
    {

        Assert.AreEqual(endTurn, actionMaster.Bowl(10));
    }
    [Test]
    public void T02Bowl8ReturnsTidy()
    {

        Assert.AreEqual(tidy, actionMaster.Bowl(8));
    }
    [Test]
    public void T03Bowl28ReturnsEndTurn()
    {
        actionMaster.Bowl(8);
        Assert.AreEqual(endTurn, actionMaster.Bowl(2));
    }


}

