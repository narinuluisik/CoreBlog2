using CoreDeneme.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoreDeneme.ViewComponents
{
	public class CommentList	:ViewComponent
	{
	  public IViewComponentResult Invoke()
		{
			var commentvalues = new List<UserComment>
			{
				new UserComment
			{
					ID=1,
					Username="Murat"

			}    ,
				new UserComment
					{
					ID=2,
					Username="narin"

			}    ,
			};
			return View(commentvalues);
		}
	}
}
