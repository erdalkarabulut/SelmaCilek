using FluentValidation;
using Bps.BpsBase.Entities.Concrete.GN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.GN
{
    public class GnkxmlValidator : AbstractValidator<GNKXML>
    {
        #region ClientService

        #endregion ClientService

        public GnkxmlValidator()
        {
            RuleFor(p => p.KULKOD).Length(1,20).NotNull();
            RuleFor(p => p.MNUNAM).Length(1,50).NotNull();
            RuleFor(p => p.MNUTAG).NotNull();
            RuleFor(p => p.GRDTAG).NotNull();
            RuleFor(p => p.GRDTXT).Length(1,50).NotNull();
            RuleFor(p => p.GRDXML).Length(1,-1).NotNull();
            RuleFor(p => p.VARSAY).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
