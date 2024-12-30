using System.Globalization;
using System.Numerics;
using System.Text;

namespace FrontierSharp.MudIndexer.Codegen;

public static class MudExtensions {
    public static (string, string) DecodeTableId(string tableId) {
        var input = tableId.Trim().Remove(0, 2);
        var inputNumeric = BigInteger.Parse(input, NumberStyles.HexNumber);
        var inputBytes = inputNumeric.ToByteArray().Reverse().ToArray();
        var result = Encoding.UTF8.GetString(inputBytes);

        return (result[2..16].TrimEnd('\0'), result[16..32].TrimEnd('\0'));
    }
    
    public static string ToPascalCase(this string input) {
        return $"{char.ToUpper(input[0])}{input[1..]}";
    }

    private static Dictionary<string, string> TableNameMapping = new() {
        { "SmartGateLinkTab", "SmartGateLink" },
        { "InventoryItemTab", "InventoryItem" },
        { "SmartGateConfigT", "SmartGateConfig" },
        { "CharactersConsta", "CharactersConstants" },
        { "DeployableFuelBa", "DeployableFuelBalance" },
        { "EntityTypeAssoci", "EntityTypeAssociation" },
        { "EntityAssociatio", "EntityAssociation" },
        { "ModuleSystemLook", "ModuleSystemLookup" },
        { "AccessEnforcemen", "AccessEnforcement" },
        { "AccessEnforcePer", "AccessEnforcementPerObject" },
        { "AccessRolePerObj", "AccessRolePerObject" },
        { "CharactersByAddr", "CharactersByAddress" },
        { "AccessRolePerSys", "AccessRolePerSystem" },
        { "SmartAssemblyTab", "SmartAssembly" },
        { "DeployableTokenT", "DeployableToken" },
        { "EntityRecordOffc", "EntityRecord" },
        { "GlobalDeployable", "GlobalDeployableState" },
        { "EntityRecordTabl", "EntityRecord" },
        { "EphemeralInvTabl", "EphemeralInventory" },
        { "EphemeralInvCapa", "EphemeralInventoryCapacity" },
        { "ItemTransferOffc", "ItemTransfer" },
        { "SmartTurretConfi", "SmartTurretConfig" },
        { "CharactersTable", "Character" },
        { "EntityTable", "Entity" },
        { "HookTable", "Hook" },
        { "ModuleTable", "Module" },
        { "StaticDataTable", "StaticData" },
    };
    
    public static string ExpandTableName(this string input) {
        return TableNameMapping.GetValueOrDefault(input.ToPascalCase(), input).ToPascalCase();
    }

    public static string GetCSharpType(this TableField tableField) {
        var abiType = tableField.AbiType;
        return abiType.EndsWith("[]") ? $"IEnumerable<{CSharpType(abiType.Remove(abiType.Length - 2))}>" : CSharpType(abiType);
    }

    private static string CSharpType(string abiType) {
        if (abiType.StartsWith("uint")) {
            var bitLength = int.Parse(abiType.Remove(0, "uint".Length));
            return bitLength switch {
                <= 8 => "byte",
                <= 16 => "ushort",
                <= 32 => "uint",
                <= 64 => "ulong",
                _ => "string"
            };
        }
        
        if (abiType.StartsWith("int")) {
            var bitLength = int.Parse(abiType.Remove(0, "int".Length));
            return bitLength switch {
                <= 8 => "sbyte",
                <= 16 => "short",
                <= 32 => "int",
                <= 64 => "long",
                _ => "string"
            };
        }
        
        if (abiType.StartsWith("bytes")) {
            return $"byte[]";
        }
        
        if (abiType.StartsWith("string")) {
            return "string";
        }
        
        if (abiType.StartsWith("bool")) {
            return "bool";
        }
        
        if (abiType.StartsWith("address")) {
            return "string";
        }
        
        if (abiType.StartsWith("tuple")) {
            return "object";
        }
        
        return "object";
    }
}