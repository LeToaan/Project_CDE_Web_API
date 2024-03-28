using System.Security.Cryptography;
using System.Text;

namespace CDE_Web_API.Helpers;

public class ContenMailHelper
{
    public static string content(string content)
    {
        var content_ = "<div class=\"section-mail\">\r\n    <div class=\"box-mail\" style=\"max-width: 400px;\r\n    width: 100%;\r\n    background: #1c95fa;\r\n    text-align: center;\r\n    color: #000000;\r\n    padding: 50px 20px;\r\n    border-radius: 20px;\">\r\n        <div class=\"box-items\">\r\n            <div class=\"head\">\r\n\r\n                <h2 class=\"title\" style=\"font-size: 40px;\r\n                font-weight: 900;\">Notification</h2>\r\n            </div>\r\n            <div class=\"content\" style=\" background: #fff;\r\n            padding: 20px;\">\r\n                <h3>Password</h3>\r\n                <div class=\"vetify-code\" style=\"display: block;\r\n                width: 50%;\r\n                margin: 0 auto;\r\n                font-size: 30px;\r\n                font-weight: 600;\">\r\n                    <p>" + content + "</p>\r\n                </div>\r\n            </div>\r\n            <div class=\"footer\">\r\n                <p class=\"name\" style=\"  font-size: 30px;\r\n                font-weight: 700;\r\n                color: #fff;\">CDE Excellent</p>\r\n                <div class=\"icon-social\" style=\"width: 100%;\r\n                display: flex;\r\n                justify-content: space-around;\">\r\n                    <a href=\"#\">\r\n                        <img src=\"https://cdn2.iconfinder.com/data/icons/social-media-2285/512/1_Facebook_colored_svg_copy-1024.png\" alt=\"\" style=\" width: 40px;\r\n                        height: 40px;\r\n                        filter: grayscale(1);\r\n                        transition: .3s;\">\r\n                    </a>\r\n                    <a href=\"#\">\r\n                        <img src=\"https://cdn2.iconfinder.com/data/icons/social-media-2285/512/1_Instagram_colored_svg_1-1024.png\" alt=\"\" style=\" width: 40px;\r\n                        height: 40px;\r\n                        filter: grayscale(1);\r\n                        transition: .3s;\">\r\n                    </a>\r\n                    <a href=\"#\">\r\n                        <img src=\"https://cdn2.iconfinder.com/data/icons/social-media-2285/512/1_Youtube_colored_svg-1024.png\" alt=\"\" style=\" width: 40px;\r\n                        height: 40px;\r\n                        filter: grayscale(1);\r\n                        transition: .3s;\">\r\n                    </a>\r\n                    <a href=\"#\">\r\n                        <img src=\"https://cdn2.iconfinder.com/data/icons/social-media-2285/512/1_Twitter3_colored_svg-1024.png\" alt=\"\" style=\" width: 40px;\r\n                        height: 40px;\r\n                       \r\n                        transition: .3s;\">\r\n                    </a>\r\n                </div>\r\n                <div class=\"copyright\">\r\n                    <p>Copyright © 2023 by ALTA SOFTWARE. All rights reserved.</p>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>";

        return content_;
    }

    public static string CreateRandomToken()
    {
        return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
    }
}
