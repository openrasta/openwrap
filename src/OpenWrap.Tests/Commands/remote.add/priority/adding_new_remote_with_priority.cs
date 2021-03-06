﻿using NUnit.Framework;
using OpenWrap.Repositories;
using OpenWrap.Testing;

namespace Tests.Commands.remote.add.priority
{
    public class adding_new_remote_with_priority : contexts.add_remote
    {
        public adding_new_remote_with_priority()
        {
            given_remote_factory_memory();
            when_executing_command("iron-hills http://lotr.org/iron-hills -priority 666");
        }

        [Test]
        public void initial_priority_is_1()
        {
            ConfiguredRemotes["iron-hills"].Priority.ShouldBe(666);
        }
    }
}