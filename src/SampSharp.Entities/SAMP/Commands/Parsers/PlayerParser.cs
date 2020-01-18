﻿// SampSharp
// Copyright 2020 Tim Potze
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using Microsoft.Extensions.DependencyInjection;

namespace SampSharp.Entities.SAMP.Commands.Parsers
{
    /// <summary>
    /// A parser for a player parameter.
    /// </summary>
    public class PlayerParser : ICommandParameterParser
    {
        private readonly WordParser _wordParser = new WordParser();

        /// <inheritdoc />
        public bool TryParse(IServiceProvider services, ref string inputText, out object result)
        {
            if (!_wordParser.TryParse(services, ref inputText, out var subResult) ||
                !(subResult is string word))
            {
                result = null;
                return false;
            }

            var entityManager = services.GetRequiredService<IEntityManager>();
            if (int.TryParse(word, out var intWord))
            {
                var entity = entityManager.Get(SampEntities.GetPlayerId(intWord));

                if (entity != null)
                {
                    result = entity;
                    return true;
                }
            }

            // TODO: Name check
            result = null;
            return false;
        }
    }
}