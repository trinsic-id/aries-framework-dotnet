using System.Threading.Tasks;
using Hyperledger.TestHarness;
using Hyperledger.TestHarness.Mock;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using System;
using Hyperledger.Aries.Features.IssueCredential;
using System.Linq;
using Hyperledger.Aries.Configuration;
using Hyperledger.Aries.Agents;
using Hyperledger.Aries.Features.PresentProof;

namespace Hyperledger.Aries.Tests.Protocols
{
    public class CredentialV1Tests// : TestSingleWallet
    {
        [Fact]
        public async Task TestRevoc()
        {
            var pair = await InProcAgent.CreatePairedAsync(true);

            var request = "{\r\n        \"name\": \"accredited-lawyer\",\r\n        \"version\": \"1.0.1\",\r\n        \"non_revoked\": {\r\n            \"from\": 1597953256,\r\n            \"to\": 1597953256\r\n        },\r\n        \"requested_attributes\": {\r\n            \"PPID\": {\r\n                \"name\": \"PPID\",\r\n                \"restrictions\": [{\r\n                    \"schema_name\": \"Practising Certificate\",\r\n                    \"schema_version\": \"0.2.0\",\r\n                    \"issuer_did\": \"RznYFPVhHpYZgsn4Hu3StV\"\r\n                }, {\r\n                    \"schema_name\": \"Practicing Certificate\",\r\n                    \"schema_version\": \"1.1.2\",\r\n                    \"issuer_did\": \"UUHA3oknprvKrpa7a6sncK\"\r\n                }]\r\n            },\r\n            \"Given Name\": {\r\n                \"name\": \"Given Name\",\r\n                \"restrictions\": [{\r\n                    \"schema_name\": \"Practising Certificate\",\r\n                    \"schema_version\": \"0.2.0\",\r\n                    \"issuer_did\": \"RznYFPVhHpYZgsn4Hu3StV\"\r\n                }, {\r\n                    \"schema_name\": \"Practicing Certificate\",\r\n                    \"schema_version\": \"1.1.2\",\r\n                    \"issuer_did\": \"UUHA3oknprvKrpa7a6sncK\"\r\n                }]\r\n            },\r\n            \"Surname\": {\r\n                \"name\": \"Surname\",\r\n                \"restrictions\": [{\r\n                    \"schema_name\": \"Practising Certificate\",\r\n                    \"schema_version\": \"0.2.0\",\r\n                    \"issuer_did\": \"RznYFPVhHpYZgsn4Hu3StV\"\r\n                }, {\r\n                    \"schema_name\": \"Practicing Certificate\",\r\n                    \"schema_version\": \"1.1.2\",\r\n                    \"issuer_did\": \"UUHA3oknprvKrpa7a6sncK\"\r\n                }]\r\n            },\r\n            \"Membership Status\": {\r\n                \"name\": \"Membership Status\",\r\n                \"restrictions\": [{\r\n                    \"schema_name\": \"Practising Certificate\",\r\n                    \"schema_version\": \"0.2.0\",\r\n                    \"issuer_did\": \"RznYFPVhHpYZgsn4Hu3StV\"\r\n                }, {\r\n                    \"schema_name\": \"Practicing Certificate\",\r\n                    \"schema_version\": \"1.1.2\",\r\n                    \"issuer_did\": \"UUHA3oknprvKrpa7a6sncK\"\r\n                }]\r\n            }\r\n        },\r\n        \"requested_predicates\": {},\r\n        \"nonce\": \"103903333717955372188208\"\r\n    }";
            var proof = "{\r\n        \"proof\": {\r\n            \"proofs\": [{\r\n                \"primary_proof\": {\r\n                    \"eq_proof\": {\r\n                        \"revealed_attrs\": {\r\n                            \"givenname\": \"76355713903561865866741292988746191972523015098789458240077478826513114743258\",\r\n                            \"membershipstatus\": \"102521883305815317207776104318259002335679112657360890741484805658633694808310\",\r\n                            \"ppid\": \"74851530145774882654383876641853677172845673229627871444740442477568528454270\",\r\n                            \"surname\": \"72066417326714592639357157411494099840335319789392267512864384015597754702049\"\r\n                        },\r\n                        \"a_prime\": \"105648734751796247473195808741368332702080376917912727279550513163296603954075893127877628328716794645231671224686158873263640899555696428048924211079211176618578243212132583316962483544656765180506056787070234640143698330871429923835528538705237323175374939870643572351994170905080026381611502623465050305530848570445471542369109618653270188913399311453277605129776776623107953871833230649688902675554260150143272135284180797458425025493564766814667011560384587447752620685638438319285315551583970615430593256188698482014655448363649135582227845225930111684010036518397812788525049904212994480082867069621682399896380\",\r\n                        \"e\": \"152081473321707845078547321646732153537175856916136273821987392042421084680396704342269979410159327340203252937882657010410614718508051131\",\r\n                        \"v\": \"484019784752832218081365125506989453300503410616640951911761445885482072096323029043308234854410252737290921869292089019223297719306039355650275093944952838104677082849418181129309691688548274138258314107425109589990795774735661046142635590911987991170696416599187301889329437279532568017907550730605173594182513688972422679212753972069597343462282121158055052130585725350253630412953640344304167659770133977992069040393957467354653814796969162137946277984735558453314945289040897305524779236290722306511874337966952666410688976592203852790218870402977520019810901364578938490705340352169801545103752086035834758863640034077421114212935141016136928771237642488586713267500211260708372215220646611898875142673658402896724090468895544696026296271676776109267435614693992466911848392353472296442883978663825925374644806315460882483815842645735154760182254412226501303076418035068386326261701310959861937596303069055339449597\",\r\n                        \"m\": {\r\n                            \"master_secret\": \"15427401770407186661490968857344543851922041418629873910382192358120625577877332774574494293966833687240826084466504390759237384856529397375056752207613370020451352282748785517049\"\r\n                        },\r\n                        \"m2\": \"5633417333030036804352287780828662711688601770405231507381457234443689950241371043995512223790217772794668005773046965793935959120942680955225374743093663\"\r\n                    },\r\n                    \"ge_proofs\": []\r\n                },\r\n                \"non_revoc_proof\": {\r\n                    \"x_list\": {\r\n                        \"rho\": \"0F90D3E8CDE29BC83B1C4D58EEBA6712BE5A5027209B5A6FA809ABF7FF81916C\",\r\n                        \"r\": \"0C12199D51BDF38785136D2C28594E2043AFFEC3B0A8FCBA4EB13F6C5B007BC1\",\r\n                        \"r_prime\": \"0941D03F832B8AED4F60205E3AE8AF3230200BE71730C17B25213A9FA0E2DA5B\",\r\n                        \"r_prime_prime\": \"11318ABB5C2FE49CF34B36F83358C8F1D21DBC109A99F8C8C0EF5321E5074B7A\",\r\n                        \"r_prime_prime_prime\": \"03853485AB5F61630EADF28E62142AB2AC03F369A78E79EC86CA2035C3F5FA0E\",\r\n                        \"o\": \"07F2B7B676DB5221A1964D432004085AE5BAD023C51FA91E72FE2B4C3F0C6034\",\r\n                        \"o_prime\": \"22332B63CCF83877B58C3E81A3F016B74538E2670FEFBF9F3E46FAEDCE7209F2\",\r\n                        \"m\": \"0862B9975A1C8C621D138DEB7A359D4514BA7108C64851CEFA48B79B38DA7B53\",\r\n                        \"m_prime\": \"0DD16F4320AF1F3DBD45DE12EE50774C010BEA10A85344EF50E8E891C44FEB44\",\r\n                        \"t\": \"055E7D37E0BDF4F4A7FCEC79298155947CD16EF96DCF163ED777FB756F11B2F8\",\r\n                        \"t_prime\": \"1B6E5C2CDB233DE051B8C3911B2C0AC10D74D16D4812052B96950A918148A9A5\",\r\n                        \"m2\": \"0647219A940AFEC2F7FF1C7D62713527B54620DD8A3F11144ED7644E1AB0E491\",\r\n                        \"s\": \"156314998FAA43180DBCF1C2CF8DB83FDBC06F51FAE1970564D9C2276DA8DA24\",\r\n                        \"c\": \"1CD81140F5FD2DD396CA74964A6623B5F52618080AA4B66FCA2470AC0FB2F938\"\r\n                    },\r\n                    \"c_list\": {\r\n                        \"e\": \"6 593D8DD837F3BDF372AF5AFA3AE89649926505237C9C39E848F98E1D9ED605A3 4 2077B53AB85BA058F6383E40C0795DBDD3ED2901DB0069C6FCED9FC4DBF01AC8 4 2201AD6E698957D8FE017BA16275CCE26F3955553DF435011C5CDCE77C0AFA65\",\r\n                        \"d\": \"6 5379EE0BDBE3C97872ACB3E0B7B2DCD5B35BFFCC68CA0BEE1451F763A324F0F1 4 237273131D48FA5846B7AE50B15304426262A23AF4E7700B7D8AF5296E1B2842 4 3A763DD8821BEF38E00A36FC0BE30E0703B6CFAB47C2309D739B184E8B852C69\",\r\n                        \"a\": \"6 5233AB07C593E0FC877E248D0EEA08B592784DC375CFB6DCCFA34EFDD3B9B568 4 1733DEA70F0A39373450667AD02DB072A902063BE94EFA96FF22CB4F83670258 4 35C1DB26EB0F33C9E30EFE5BE2ACC8E64DEC04F5280ABC8C357F6BE29BF4FAFF\",\r\n                        \"g\": \"6 465CA533AC385340B43BDA2F92DDB5A8E3A1644C3735F4FB620BFC8E18FAEFCD 4 0C516A528DB94B56A4D2767F8B6298116BF6F05B68FB67DEC1741D311B6D26E4 4 3A22C8917019F7672DC94B39CE65E0C3BD0366BBB39D405E1A55D9E7348D62A5\",\r\n                        \"w\": \"21 1216835F7985729D9C2ACC1366D896DCB3F81234FC56F195B2DBD0932520D17C4 21 13A5F287185CFF04EEC8B40C13EAB0104043210495B06852C3DC5EBEE43301C7E 6 85CB0F49F2B33DA12134F6587FCD989DA38B12DBC2CD677358F8975E7D686128 4 31BE9EAA405E0202F32132F1F7D95F8AFE68481D4BED6DABCB417ECF321A8B1F 6 7168319440894898E7A1B6A96F3E32BA8F0E311B7213F38259AF4A4590CD8045 4 1D6E1DCFC6C70E2EA7454ED4DC16C7D19186B4982312A242FEA0422BB8BC8261\",\r\n                        \"s\": \"21 1257E24CBBD2A342D202832DFBF4C01D7773E1A1448DACDADB1F01F9312CAD38E 21 117983716DCC63845EB604E2CE334F9DB7C93E5B5E98A83792D1DAD7D7EE64C55 6 52077F8AE6BD34F11910282D13FE30C167899DD9687335306FC378607FA4B754 4 12208EE7D67C430A2A3512DF423686CB855F50E2C1F38640F6AB197A12C82574 6 621AE32A30BB1CF36E316A1951162EDFBCC6925AE62443A34CA8545CCA571060 4 1EDB27B3B58BA0DECB298D5BC370FF5B1F0401C78B62ABB347FDFFCAF9B70464\",\r\n                        \"u\": \"21 111F46813794035E75910809B03AA18892E4464D1D61657469034D3A7EFC215D4 21 11E8A1CAD8811235A736EE180A3C690CE84A92CDF1BF81E599E809CDBDE687F76 6 6164A7CF8FBC6501CC504127A36A5ECA2E1E956D729E0DC7E14AD1EC1F712D4D 4 0A17DD13C3E660164432EAC61B8628B369404FF9FF479E5178276FFA9012B52E 6 7F558B4F9ECC89751AD0077FC9C13401346A4282EF84A26B82D6563D54A4F95F 4 157749AF15A98A6853879A468D1ACE5C6586EDF84E6001C9311D9C1496D76273\"\r\n                    }\r\n                }\r\n            }],\r\n            \"aggregated_proof\": {\r\n                \"c_hash\": \"83437594130488619100752939660952071354215853696580909561542153449964636440862\",\r\n                \"c_list\": [\r\n                    [4, 13, 204, 242, 153, 66, 234, 136, 123, 127, 254, 186, 200, 116, 63, 137, 246, 178, 188, 211, 146, 239, 186, 160, 28, 198, 241, 97, 39, 130, 128, 223, 184, 20, 51, 230, 75, 41, 75, 108, 85, 5, 202, 178, 102, 99, 50, 43, 130, 187, 9, 179, 241, 164, 145, 117, 122, 175, 220, 241, 246, 242, 74, 124, 119, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],\r\n                    [4, 2, 129, 247, 70, 199, 57, 174, 167, 218, 252, 50, 17, 227, 151, 248, 255, 230, 145, 227, 186, 78, 162, 22, 173, 137, 180, 63, 68, 108, 213, 46, 213, 2, 126, 72, 164, 247, 73, 124, 236, 33, 102, 19, 210, 224, 152, 191, 10, 157, 158, 234, 161, 99, 91, 59, 35, 160, 148, 97, 87, 194, 94, 91, 179, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],\r\n                    [4, 5, 150, 71, 113, 0, 226, 132, 252, 168, 56, 28, 149, 95, 76, 162, 43, 204, 119, 239, 4, 76, 103, 65, 53, 68, 49, 60, 3, 16, 122, 168, 123, 30, 239, 116, 77, 79, 163, 198, 67, 145, 36, 35, 252, 175, 64, 133, 142, 225, 137, 142, 194, 44, 67, 17, 166, 56, 50, 221, 44, 186, 92, 117, 117, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],\r\n                    [4, 30, 46, 149, 177, 193, 21, 202, 189, 116, 29, 149, 72, 71, 158, 43, 68, 5, 106, 56, 76, 0, 151, 204, 172, 108, 50, 148, 218, 174, 48, 181, 76, 34, 7, 113, 152, 200, 5, 42, 201, 184, 3, 139, 74, 66, 91, 47, 35, 216, 124, 92, 11, 125, 158, 118, 97, 158, 13, 223, 248, 199, 198, 189, 103, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0],\r\n                    [31, 199, 241, 237, 91, 25, 235, 55, 215, 144, 98, 141, 23, 51, 174, 56, 21, 1, 247, 125, 204, 53, 229, 208, 46, 106, 230, 62, 111, 42, 96, 119, 20, 60, 219, 237, 190, 47, 43, 139, 174, 184, 147, 35, 106, 190, 63, 2, 112, 127, 83, 240, 48, 86, 47, 96, 7, 194, 145, 180, 44, 220, 228, 171, 7, 154, 25, 170, 167, 90, 94, 234, 94, 107, 224, 0, 220, 129, 198, 148, 32, 5, 42, 184, 77, 228, 45, 196, 166, 16, 72, 87, 4, 87, 2, 155, 16, 92, 49, 145, 183, 116, 221, 161, 49, 59, 129, 222, 74, 51, 197, 15, 42, 56, 194, 236, 144, 87, 201, 111, 84, 81, 99, 163, 31, 151, 157, 122],\r\n                    [27, 3, 111, 84, 63, 161, 210, 30, 168, 98, 188, 254, 197, 219, 153, 135, 241, 50, 72, 54, 67, 195, 136, 171, 38, 151, 213, 182, 201, 233, 187, 133, 21, 80, 39, 14, 158, 6, 141, 76, 160, 241, 121, 87, 218, 156, 237, 126, 31, 26, 123, 80, 168, 67, 185, 40, 46, 184, 69, 66, 58, 41, 238, 144, 13, 17, 246, 99, 108, 40, 188, 200, 231, 170, 18, 1, 235, 207, 1, 148, 43, 214, 26, 134, 224, 79, 155, 84, 206, 145, 233, 53, 254, 35, 60, 113, 25, 162, 181, 121, 182, 157, 105, 121, 31, 199, 222, 43, 147, 14, 24, 248, 71, 205, 131, 135, 95, 89, 199, 128, 189, 25, 248, 214, 72, 159, 66, 60],\r\n                    [34, 99, 139, 151, 243, 147, 70, 228, 173, 19, 238, 132, 247, 132, 56, 64, 61, 186, 125, 207, 141, 7, 55, 74, 27, 166, 24, 4, 124, 239, 93, 134, 25, 245, 49, 197, 36, 255, 173, 139, 117, 59, 134, 215, 12, 93, 75, 237, 5, 172, 83, 201, 174, 164, 29, 147, 159, 12, 121, 103, 243, 42, 51, 230, 5, 113, 30, 184, 113, 35, 168, 80, 142, 83, 58, 254, 139, 46, 204, 22, 86, 73, 170, 181, 46, 127, 69, 184, 0, 44, 231, 132, 38, 11, 179, 127, 35, 194, 244, 103, 219, 179, 174, 116, 157, 170, 104, 111, 235, 147, 251, 99, 118, 0, 151, 96, 186, 87, 65, 14, 173, 93, 64, 149, 186, 212, 154, 87],\r\n                    [3, 68, 230, 49, 24, 222, 27, 242, 98, 130, 54, 3, 136, 6, 217, 223, 50, 91, 218, 141, 119, 175, 150, 143, 208, 104, 83, 5, 47, 66, 22, 70, 181, 36, 245, 143, 177, 30, 84, 12, 7, 119, 183, 133, 170, 43, 138, 166, 247, 68, 20, 94, 179, 72, 6, 31, 142, 167, 245, 64, 32, 201, 2, 28, 228, 230, 173, 74, 67, 39, 44, 22, 87, 230, 228, 116, 167, 68, 102, 145, 207, 149, 252, 159, 7, 132, 162, 7, 67, 69, 90, 40, 18, 186, 98, 237, 198, 204, 201, 134, 227, 180, 101, 141, 75, 93, 249, 42, 213, 61, 225, 24, 57, 189, 102, 62, 196, 134, 154, 235, 123, 133, 103, 79, 156, 224, 41, 131, 165, 85, 226, 116, 0, 78, 185, 116, 134, 141, 87, 160, 209, 199, 138, 251, 54, 122, 193, 244, 147, 170, 11, 159, 29, 248, 25, 127, 148, 220, 10, 14, 102, 75, 93, 120, 205, 143, 6, 176, 139, 125, 135, 153, 76, 162, 44, 198, 4, 58, 201, 198, 99, 7, 64, 206, 123, 185, 62, 36, 46, 237, 174, 88, 162, 133, 154, 220, 158, 170, 160, 223, 51, 52, 19, 52, 101, 84, 248, 104, 233, 7, 202, 118, 119, 98, 176, 29, 55, 80, 103, 119, 137, 214, 97, 68, 243, 167, 222, 184, 68, 234, 175, 51, 58, 26, 39, 242, 215, 84, 129, 70, 181, 19, 114, 229, 130, 248, 18, 182, 250, 171, 154, 150, 70, 7, 8, 99, 60]\r\n                ]\r\n            }\r\n        },\r\n        \"requested_proof\": {\r\n            \"revealed_attrs\": {\r\n                \"Membership Status\": {\r\n                    \"sub_proof_index\": 0,\r\n                    \"raw\": \"PRAC\",\r\n                    \"encoded\": \"102521883305815317207776104318259002335679112657360890741484805658633694808310\"\r\n                },\r\n                \"PPID\": {\r\n                    \"sub_proof_index\": 0,\r\n                    \"raw\": \"PC123456\",\r\n                    \"encoded\": \"74851530145774882654383876641853677172845673229627871444740442477568528454270\"\r\n                },\r\n                \"Given Name\": {\r\n                    \"sub_proof_index\": 0,\r\n                    \"raw\": \"John\",\r\n                    \"encoded\": \"76355713903561865866741292988746191972523015098789458240077478826513114743258\"\r\n                },\r\n                \"Surname\": {\r\n                    \"sub_proof_index\": 0,\r\n                    \"raw\": \"Smith\",\r\n                    \"encoded\": \"72066417326714592639357157411494099840335319789392267512864384015597754702049\"\r\n                }\r\n            },\r\n            \"self_attested_attrs\": {},\r\n            \"unrevealed_attrs\": {},\r\n            \"predicates\": {}\r\n        },\r\n        \"identifiers\": [{\r\n            \"schema_id\": \"UUHA3oknprvKrpa7a6sncK:2:Practicing Certificate:1.1.2\",\r\n            \"cred_def_id\": \"UUHA3oknprvKrpa7a6sncK:3:CL:135204:dev1.0.0\",\r\n            \"rev_reg_id\": \"UUHA3oknprvKrpa7a6sncK:4:UUHA3oknprvKrpa7a6sncK:3:CL:135204:dev1.0.0:CL_ACCUM:c7f9cdfa-ce2d-4ac6-ab4f-f545ee421624\",\r\n            \"timestamp\": 1597883340\r\n        }]\r\n    }";

            var proofService = pair.Agent1.Provider.GetRequiredService<IProofService>();

            var valid = proofService.VerifyProofAsync(pair.Agent1.Context, request, proof);
        }

        //[Fact(DisplayName = "Test Credential Issuance Protocol v1.0")]
        //public async Task TestCredentialIssuanceV1()
        //{
        //    var pair = await InProcAgent.CreatePairedAsync(true);

        //    // Configure agent1 as issuer
        //    var issuerConfiguration = await pair.Agent1.Provider.GetRequiredService<IProvisioningService>()
        //        .GetProvisioningAsync(pair.Agent1.Context.Wallet);
        //    await PromoteTrustAnchor(issuerConfiguration.IssuerDid, issuerConfiguration.IssuerVerkey);

        //    var schemaId = await pair.Agent1.Provider.GetRequiredService<ISchemaService>()
        //        .CreateSchemaAsync(
        //            context: pair.Agent1.Context,
        //            issuerDid: issuerConfiguration.IssuerDid,
        //            name: $"test-schema-{Guid.NewGuid().ToString()}",
        //            version: "1.0",
        //            attributeNames: new[] { "name" });

        //    var definitionId = await pair.Agent1.Provider.GetRequiredService<ISchemaService>()
        //        .CreateCredentialDefinitionAsync(
        //            context: pair.Agent1.Context,
        //            schemaId: schemaId,
        //            issuerDid: issuerConfiguration.IssuerDid,
        //            tag: "tag",
        //            supportsRevocation: false,
        //            maxCredentialCount: 0,
        //            tailsBaseUri: new Uri("http://localhost"));

        //    // Send offer
        //    var (offer, record) = await pair.Agent1.Provider.GetRequiredService<ICredentialService>()
        //        .CreateOfferAsync(pair.Agent1.Context, new OfferConfiguration
        //        {
        //            CredentialDefinitionId = definitionId,
        //            IssuerDid = issuerConfiguration.IssuerDid,
        //            CredentialAttributeValues = new [] { new CredentialPreviewAttribute("name", "random") }
        //        });
        //    await pair.Agent1.Provider.GetRequiredService<IMessageService>()
        //        .SendAsync(pair.Agent1.Context.Wallet, offer, pair.Connection1);

        //    // Find credential for Agent 2
        //    var credentials = await pair.Agent2.Provider.GetService<ICredentialService>()
        //        .ListAsync(pair.Agent2.Context);
        //    var credential = credentials.First();

        //    // Accept the offer and send request
        //    var (request, _) = await pair.Agent2.Provider.GetService<ICredentialService>()
        //        .CreateRequestAsync(pair.Agent2.Context, credential.Id);
        //    await pair.Agent2.Provider.GetService<IMessageService>()
        //        .SendAsync(pair.Agent2.Context.Wallet, request, pair.Connection2);

        //    // Issue credential
        //    var (issue, _) = await pair.Agent1.Provider.GetRequiredService<ICredentialService>()
        //        .CreateCredentialAsync(pair.Agent1.Context, record.Id);
        //    await pair.Agent1.Provider.GetService<IMessageService>()
        //        .SendAsync(pair.Agent1.Context.Wallet, issue, pair.Connection1);

        //    // Assert
        //    var credentialHolder = await pair.Agent2.Provider.GetService<ICredentialService>()
        //        .GetAsync(pair.Agent2.Context, credential.Id);
        //    var credentialIssuer = await pair.Agent1.Provider.GetService<ICredentialService>()
        //        .GetAsync(pair.Agent1.Context, record.Id);

        //    Assert.Equal(CredentialState.Issued, credentialHolder.State);
        //    Assert.Equal(CredentialState.Issued, credentialIssuer.State);
        //}
    }
}
