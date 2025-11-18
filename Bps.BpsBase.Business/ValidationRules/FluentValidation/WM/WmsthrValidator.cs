using FluentValidation;
using Bps.BpsBase.Entities.Concrete.WM;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.ValidationRules.FluentValidation.WM
{
    public class WmsthrValidator : AbstractValidator<WMSTHR>
    {
        #region ClientService

        #endregion ClientService

        public WmsthrValidator()
        {
            RuleFor(p => p.BELGEN).Length(1,20).NotNull();
            RuleFor(p => p.BELTRH).NotNull();
            RuleFor(p => p.STHRTP).NotNull();
            RuleFor(p => p.STFTNO).NotNull();
            RuleFor(p => p.SATIRN).NotNull();
            RuleFor(p => p.STKODU).Length(1,25).NotNull();
            RuleFor(p => p.GNMKTR).NotNull();
            RuleFor(p => p.OLCUKD).Length(1,20).NotNull();
            RuleFor(p => p.DPADRS).Length(1,50).NotNull();


            #region ClientValidator

            #endregion ClientValidator
        }
    }
}
